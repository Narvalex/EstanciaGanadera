﻿using EstanciaGanadera.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;

namespace EstanciaGanadera.Server
{
    public static class MensajeAuditableExtensions
    {
        public static T ConFirma<T>(this T mensaje, HttpActionContext context) where T : MensajeAuditable
        {
            var proveedor = ServiceLocator.ResolveSingleton<IProveedorDeFirmaDelUsuario>();

            var headerValue = GetTokenHeaderValue();
            if (headerValue == null)
                throw new ArgumentNullException("AuthenticationHeaderValue");

            AuthenticationHeaderValue tokenDescriptor;
            if (!AuthenticationHeaderValue.TryParse(headerValue, out tokenDescriptor))
                throw new ArgumentException("Could not parse the auth header. Maybe the token is not valid.", "AuthenticationHeaderValue");

            var metadatos = proveedor.ObtenerFirmaDelUsuario(tokenDescriptor.Parameter);

            mensaje.TrySet(metadatos);

            return mensaje;

            string GetTokenHeaderValue()
            {
                IEnumerable<string> values;
                return context
                            .Request
                            .Headers
                            .TryGetValues("Authorization", out values)
                            ? values.First()
                            : null;
            }
        }
    }
}
