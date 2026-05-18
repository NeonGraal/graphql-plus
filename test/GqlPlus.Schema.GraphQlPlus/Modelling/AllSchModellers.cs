using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Schema.Modelling;

public static class AllSchModellers
{
  public static IServiceCollection AddSchModellers(this IServiceCollection services, Action<ISchModellerRepositoryBuilder> config)
    => services.ThrowIfNull()
      .AddSingleton(new SchModellerRepositoryBuilder().FluentAction(b => config(b)))
      .AddSingleton<ISchModellerRepository, SchModellerRepository>()
      .AddSingleton<IModeller<IAstSchema, ISch_SchemaObject>, SchSchemaModeller>();

  internal static ISchModellerRepository CreateDefaultRepository()
    => new SchModellerRepository(new SchModellerRepositoryBuilder().FluentAction(b => AddSchSchemaModellers(b)));

  public static ISchModellerRepositoryBuilder AddSchSchemaModellers(this ISchModellerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddModeller(SchModifierModeller.Factory)
      .AddModeller(SchCategoryModeller.Factory)
      .AddModeller(SchDirectiveModeller.Factory)
      .AddModeller(SchSettingModeller.Factory)
      .AddModeller(SchEnumModeller.Factory)
      .AddModeller(SchUnionModeller.Factory)
      .AddModeller(SchDomainBooleanModeller.Factory)
      .AddModeller(SchDomainEnumModeller.Factory)
      .AddModeller(SchDomainNumberModeller.Factory)
      .AddModeller(SchDomainStringModeller.Factory)
      .AddModeller(SchSpecialModeller.Factory)
      .AddModeller(SchDualModeller.Factory)
      .AddModeller(SchInputModeller.Factory)
      .AddModeller(SchOutputModeller.Factory)
      .AddModeller(SchSchemaModeller.Factory);
}
