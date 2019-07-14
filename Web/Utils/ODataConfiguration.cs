using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Models.Db.Entities;

namespace Web.Utils
{
	public class ODataConfiguration : IModelConfiguration
	{
		public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
		{
			builder.EntitySet<FilmText>(nameof(FilmText))
				.EntityType.HasKey(k => k.FilmId).Filter().Count().OrderBy().Select().Page();
			builder.EntitySet<Film>(nameof(Film))
				.EntityType.HasKey(k => k.FilmId)
				.Select().Filter().Expand().OrderBy().Page().Count();

			// builder.EntitySet<Film>(nameof(Film)).HasManyBinding<FilmActor>(k=>k.FilmActor, nameof(FilmActor))
			// 	.EntityType.HasKey(k => k.FilmId)
			// 	.Select().Filter().Count().OrderBy().Page().Expand();

		}
	}
}