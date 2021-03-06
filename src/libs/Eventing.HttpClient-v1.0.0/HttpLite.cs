﻿using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Eventing.Client.Http
{
    /// <summary>
    /// This could be a whole lot improved with a limited pool
    /// https://pastebin.com/jftEbWrc
    /// https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    /// This is a little discusion about it.
    /// For multiclient (like a web server) there is no way to make a pool of http clients efficiently, but 
    /// for a single client (like a WinForm app) we could just have an instance of http lite
    /// </summary>
    public class HttpLite : IHttpLite
    {
        private readonly string hostUri;
        private Func<string> threadSafeTokenProvider = () => string.Empty;

        public HttpLite(string hostUri)
        {
            Ensure.NotNullOrWhiteSpace(hostUri, nameof(hostUri));

            this.hostUri = hostUri;
        }

        public async Task<TResult> Get<TResult>(string uri, string token = null)
        {
            using (var client = this.CreateHttpClient(token))
            {
                var endpoint = new Uri(new Uri(this.hostUri), uri);
                var response = await client.GetAsync(endpoint.AbsoluteUri);

                this.EnsureResponseIsOk(uri, response);
                var result = await response.Content.ReadAsAsync<TResult>();
                return result;

            }
        }

        public async Task<Stream> Get(string uri, string token = null)
        {
            using (var client = this.CreateHttpClient(token))
            {
                var endpoint = new Uri(new Uri(this.hostUri), uri);
                var response = await client.GetAsync(endpoint.AbsoluteUri);
                this.EnsureResponseIsOk(uri, response);
                var stream = await response.Content.ReadAsStreamAsync();
                return stream;

            }
        }

        public async Task Post(string uri, string jsonContent, string token = null)
        {
            using (var client = this.CreateHttpClient(token))
            {
                var tokenEndpoint = new Uri(new Uri(this.hostUri), uri);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(tokenEndpoint, stringContent);

                this.EnsureResponseIsOk(uri, response);
            }
        }

        public async Task<TResult> Post<TResult>(string uri, string jsonContent, string token = null)
        {
            using (var client = this.CreateHttpClient(token))
            {
                var tokenEndpoint = new Uri(new Uri(this.hostUri), uri);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(tokenEndpoint, stringContent);

                this.EnsureResponseIsOk(uri, response);

                var responseContent = await response.Content.ReadAsAsync<TResult>();
                return responseContent;

            }
        }

        // to build a stream from a byte array = new MemoryStream(byteArray);
        //
        public async Task Upload(string uri, Stream fileStream, string fileName, string metadatos, string token = null)
        {
            // Reference: https://stackoverflow.com/questions/16416601/c-sharp-httpclient-4-5-multipart-form-data-upload?noredirect=1&lq=1

            using (var client = this.CreateHttpClient(token, false))
            {
                using (var content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
                {
                    content.Add(new StreamContent(fileStream), "uploadedFile", fileName);
                    content.Add(new StringContent(metadatos));

                    var endpoint = new Uri(new Uri(this.hostUri), uri);
                    var url = endpoint.AbsoluteUri;
                    var response = await client.PostAsync(url, content);

                    this.EnsureResponseIsOk(uri, response);

                }
            }
        }

        public async Task<TResult> Upload<TResult>(string uri, Stream fileStream, string fileName, string metadatos, string token = null)
        {
            // Reference: https://stackoverflow.com/questions/16416601/c-sharp-httpclient-4-5-multipart-form-data-upload?noredirect=1&lq=1

            using (var client = this.CreateHttpClient(token, false))
            {
                using (var content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
                {
                    content.Add(new StreamContent(fileStream), "uploadedFile", fileName);
                    content.Add(new StringContent(metadatos));

                    var endpoint = new Uri(new Uri(this.hostUri), uri);
                    var url = endpoint.AbsoluteUri;
                    var response = await client.PostAsync(url, content);

                    this.EnsureResponseIsOk(uri, response);
                    var dto = await response.Content.ReadAsAsync<TResult>();
                    return dto;
                }
            }
        }

        public async Task Post<TContent>(string uri, TContent content, string token = null)
        {
            await this.TryPostAsJson<TContent>(uri, content, token);
        }

        public async Task<TResult> Post<TContent, TResult>(string uri, TContent content, string token = null)
        {
            var response = await this.TryPostAsJson(uri, content, token);

            var responseContent = await response.Content.ReadAsAsync<TResult>();
            return responseContent;

        }

        private async Task<HttpResponseMessage> TryPostAsJson<TContent>(string uri, TContent content, string token)
        {
            using (var client = this.CreateHttpClient(token))
            {
                var endpoint = new Uri(new Uri(this.hostUri), uri);
                var response = await client.PostAsJsonAsync<TContent>(endpoint.AbsoluteUri, content);
                this.EnsureResponseIsOk(uri, response);
                return response;

            }
        }

        private HttpClient CreateHttpClient(string token, bool isJson = true)
        {
            var client = new HttpClient();
            if (isJson)
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (token != null)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        private void EnsureResponseIsOk(string uri, HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new RemoteUnauthrorizedResponseException();
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode == HttpStatusCode.BadGateway)
                throw new ServiceUnavailableException($"The uri {uri} is unavailable");
            else
                throw new Exception($"Error on posting to {uri}. Status Code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
        }
    }
}
