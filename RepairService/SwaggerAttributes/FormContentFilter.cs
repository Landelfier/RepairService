using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using System.Linq;
using System.Collections.Generic;

namespace RepairService.Models
{
    public class FormContentFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<FormContentAttribute>().FirstOrDefault();
            if (attribute == null) return;

            var uploadFileMediaType = new OpenApiMediaType
            {
                Schema = new OpenApiSchema()
                {
                    Type = "object",
                    Properties = ConfigurFormProperties(attribute.elements),
                    Required = ConfigureRequiredProperties(attribute.elements)
                }
            };
            operation.RequestBody = new OpenApiRequestBody
            {
                Content =
                {
                    ["application/x-www-form-urlencoded"] = uploadFileMediaType
                }
            };
        }

        private IDictionary<string, OpenApiSchema> ConfigurFormProperties(IEnumerable<FormContentElement> decorateAttributes) =>
            decorateAttributes.Select(x=>
            new KeyValuePair<string, OpenApiSchema>(
                x.ParameterName, new OpenApiSchema()
                {
                    Description = x.Description,
                    Type = x.Format
                }
            )).ToDictionary(x=>x.Key,x=>x.Value);

        private HashSet<string> ConfigureRequiredProperties(IEnumerable<FormContentElement> decorateAttributes) =>
            new HashSet<string>(
            decorateAttributes
                .Where(x => x.Required)
                .Select(x => x.ParameterName));
    }
}
