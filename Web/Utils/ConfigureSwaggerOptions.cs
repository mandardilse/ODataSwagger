using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web.Utils
{
	internal class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider provider;

		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

		public void Configure(SwaggerGenOptions options)
		{
			foreach (var description in provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
			}
		}

		private Info CreateInfoForApiVersion(ApiVersionDescription description)
		{
			var info = new Info()
			{
				Title = "ODataSwagger Example",
				Version = description.ApiVersion.ToString()
			};
			if (description.IsDeprecated)
				info.Description = " This API version has been deprecated.";
			return info;
		}
	}
}