using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Schema.Modelling;

public static class AllSchModellers
{
  public static IServiceCollection AddSchModellers(this IServiceCollection services)
    => services.ThrowIfNull()
      .AddSingleton<IModeller<IAstModifier, ISch_Modifiers>, SchModifierModeller>()
      .AddSingleton<IModeller<IAstSchemaCategory, ISch_Category>, SchCategoryModeller>()
      .AddSingleton<IModeller<IAstSchemaDirective, ISch_Directive>, SchDirectiveModeller>()
      .AddSingleton<IModeller<IAstSchemaSetting, ISch_Setting>, SchSettingModeller>()
      .AddSingleton<IModeller<IAstEnum, ISch_Type>, SchEnumModeller>()
      .AddSingleton<IModeller<IAstUnion, ISch_Type>, SchUnionModeller>()
      .AddSingleton<IModeller<IAstDomain<IAstDomainTrueFalse>, ISch_Type>, SchDomainBooleanModeller>()
      .AddSingleton<IModeller<IAstDomain<IAstDomainLabel>, ISch_Type>, SchDomainEnumModeller>()
      .AddSingleton<IModeller<IAstDomain<IAstDomainRange>, ISch_Type>, SchDomainNumberModeller>()
      .AddSingleton<IModeller<IAstDomain<IAstDomainRegex>, ISch_Type>, SchDomainStringModeller>()
      .AddSingleton<IModeller<IAstTypeSpecial, ISch_Type>, SchSpecialModeller>()
      .AddSingleton<IModeller<IAstObject<IAstDualField>, ISch_Type>, SchDualModeller>()
      .AddSingleton<IModeller<IAstObject<IAstInputField>, ISch_Type>, SchInputModeller>()
      .AddSingleton<IModeller<IAstObject<IAstOutputField>, ISch_Type>, SchOutputModeller>()
      .AddSingleton<IModeller<IAstSchema, ISch_SchemaObject>, SchSchemaModeller>();
}
