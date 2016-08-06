using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger.Model;

namespace Telepresence.API.Documentation
{
    /// <summary>
    /// Extension to configure Swagger
    /// </summary>
    public static class DocumentationExtension
    {
        /// <summary>
        /// Configures Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Documentação da API",
                    Description = "Documentação da API Rest com Swagger",
                    TermsOfService = "Termos do serviço",
                });
                x.IncludeXmlComments("C:\\repos\\telepresence-api\\Telepresence.API\\src\\Telepresence.API\\bin\\Debug\\net452\\win7-x64\\Telepresence.API.xml");
            });
        }
        
        /// <summary>
        /// Register Swagger UI use
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwagger(this IApplicationBuilder app)
        {
            app.UseSwaggerUi();
        }
    }
}
