using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace MeuPet.API.Middlewares
{
    public class AuthenticateMiddleware
    {
        readonly RequestDelegate _next;

        public AuthenticateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var auth = context.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrWhiteSpace(auth))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            if (string.IsNullOrEmpty(auth))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            auth = auth.Replace("Basic ", "");

            try
            {
                var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(auth));

                var usuario = new Usuario
                {
                    Nome = decodedToken.Split(':')[0],
                    Senha = decodedToken.Split(':')[1]
                };

                context.Items.Add("usuario", usuario);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            await _next.Invoke(context);
        }
    }
}
