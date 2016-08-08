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
        ///// <summary>
        ///// Configures Swagger
        ///// </summary>
        ///// <param name="services"></param>
        //public static void AddSwagger(this IServiceCollection services)
        //{
        //    services.AddSwagger(s =>
        //    {
        //        s.SwaggerGenerator(c =>
        //        {
        //            c.Schemes = new[] { "http", "https" };
        //            c.SingleApiVersion(new Info
        //            {
        //                Version = "v1",
        //                Title = "Swashbuckle Sample API",
        //                Description = "A sample API for testing Swashbuckle",
        //                TermsOfService = "Some terms ..."
        //            });
        //        });

        //        s.SchemaGenerator(opt => opt.DescribeAllEnumsAsStrings = true);
        //    });
        //}
        
        ///// <summary>
        ///// Register Swagger UI use
        ///// </summary>
        ///// <param name="app"></param>
        //public static void UseSwagger(this IApplicationBuilder app)
        //{
        //    app.UseSwaggerUi();
        //    app.UseSwaggerGen();
        //}
    }
}
