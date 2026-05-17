using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Schema.Modelling;

public static class AllSchModellers
{
  public static IServiceCollection AddSchModellers(this IServiceCollection services)
    => services.ThrowIfNull()
      .AddSingleton(BuildRepository())
      .AddSingleton<ISchModellerRepository, SchModellerRepository>()
      .AddSingleton<IModeller<IAstSchema, ISch_SchemaObject>, SchSchemaModeller>();

  internal static ISchModellerRepository CreateDefaultRepository()
    => new SchModellerRepository(BuildRepository());

  private static SchModellerRepositoryBuilder BuildRepository()
    => new SchModellerRepositoryBuilder()
      .AddModeller<IAstModifier, ISch_Modifiers>(SchModifierModeller.Factory)
      .AddModeller<IAstSchemaCategory, ISch_Category>(SchCategoryModeller.Factory)
      .AddModeller<IAstSchemaDirective, ISch_Directive>(SchDirectiveModeller.Factory)
      .AddModeller<IAstSchemaSetting, ISch_Setting>(SchSettingModeller.Factory)
      .AddModeller<IAstEnum, ISch_Type>(SchEnumModeller.Factory)
      .AddModeller<IAstUnion, ISch_Type>(SchUnionModeller.Factory)
      .AddModeller<IAstDomain<IAstDomainTrueFalse>, ISch_Type>(SchDomainBooleanModeller.Factory)
      .AddModeller<IAstDomain<IAstDomainLabel>, ISch_Type>(SchDomainEnumModeller.Factory)
      .AddModeller<IAstDomain<IAstDomainRange>, ISch_Type>(SchDomainNumberModeller.Factory)
      .AddModeller<IAstDomain<IAstDomainRegex>, ISch_Type>(SchDomainStringModeller.Factory)
      .AddModeller<IAstTypeSpecial, ISch_Type>(SchSpecialModeller.Factory)
      .AddModeller<IAstObject<IAstDualField>, ISch_Type>(SchDualModeller.Factory)
      .AddModeller<IAstObject<IAstInputField>, ISch_Type>(SchInputModeller.Factory)
      .AddModeller<IAstObject<IAstOutputField>, ISch_Type>(SchOutputModeller.Factory)
      .AddModeller<IAstSchema, ISch_SchemaObject>(SchSchemaModeller.Factory);
}
