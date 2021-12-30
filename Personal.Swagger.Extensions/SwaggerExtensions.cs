using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Personal.Swagger
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder UseSwaggerProxy(this IApplicationBuilder applicationBuilder, string basePath)
        {
            applicationBuilder.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    httpReq.Headers.TryGetValue("Referer", out var refererHeader);

                    var port = GetPort(refererHeader);

                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}:{port}/{basePath}" } };
                });
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            return applicationBuilder;
        }

        private static string GetPort(string url)
        {
            Regex r = new(@"//[^/]+?(?<port>\d+)?/", RegexOptions.None, TimeSpan.FromMilliseconds(150));
            Match m = r.Match(url);

            if (m.Success) return m.Groups["port"].Value;

            return string.Empty;
        }
    }
}
