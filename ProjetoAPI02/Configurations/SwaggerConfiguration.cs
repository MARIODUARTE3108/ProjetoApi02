using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            #region Swagger

            services.AddSwaggerGen(
               swagger =>
               {
                   swagger.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Title = "API - Loja de Produtos (eCommerce)",
                       Description = "API REST desenvolvida em .NET CORE com Dapper",
                       Version = "v1",
                       Contact = new OpenApiContact
                       {
                           Name = "COTI Informática",
                           Url = new Uri("http://www.cotiinformatica.com.br"),
                           Email = "contato@cotiinformatica.com.br"
                       }
                   });
               }
               );

            #endregion
        }
    }
}

