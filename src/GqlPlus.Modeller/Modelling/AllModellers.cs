using System.Diagnostics.CodeAnalysis;
using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Modelling;

public static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
  {
    ModellerRepositoryBuilder builder = new();
    builder.AddSchemaModellers();
    services.AddSingleton(builder);
    services.TryAddSingleton<IModellerRepository, ModellerRepository>();
    return services;
  }

  [ExcludeFromCodeCoverage]
  internal static IModellerRepositoryBuilder AddSchemaModellers(this IModellerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddModeller<IAstEnumValue, EnumValueModel>(EnumValueModeller.Factory)
      .AddModeller<IAstFieldKey, SimpleModel>(SimpleModeller.Factory)
      .AddModeller<IAstConstant, ConstantModel>(ConstantModeller.Factory)
      .AddModifierModeller(ModifierModeller.Factory)
      .AddModeller<IAstModifier, ModifierModel>(r => r.ModifierModeller)
      .AddModeller<IAstModifier, CollectionModel>(r => r.ModifierModeller)
      // Schema
      .AddModeller<IAstSchema, SchemaModel>(SchemaModeller.Factory)
      .AddModeller<IAstSchemaCategory, CategoryModel>(CategoryModeller.Factory)
      .AddModeller<IAstSchemaDirective, DirectiveModel>(DirectiveModeller.Factory)
      .AddModeller<IAstSchemaSetting, SettingModel>(SettingModeller.Factory)
      // Types
      .AddTypesModeller(TypesModeller.Factory)
      .AddModeller<IAstType, BaseTypeModel>(r => r.TypesModeller)
      .AddTypeModeller<IAstTypeSpecial, SpecialTypeModel>(SpecialTypeModeller.Factory)
      // Simple - Domain
      .AddTypeModeller<IAstDomain<IAstDomainLabel>, BaseDomainModel<DomainLabelModel>>(DomainEnumModeller.Factory)
      .AddTypeModeller<IAstDomain<IAstDomainRange>, BaseDomainModel<DomainRangeModel>>(DomainNumberModeller.Factory)
      .AddTypeModeller<IAstDomain<IAstDomainRegex>, BaseDomainModel<DomainRegexModel>>(DomainStringModeller.Factory)
      .AddTypeModeller<IAstDomain<IAstDomainTrueFalse>, BaseDomainModel<DomainTrueFalseModel>>(DomainBooleanModeller.Factory)
      .AddTypeModeller<IAstEnum, TypeEnumModel>(EnumModeller.Factory)
      .AddTypeModeller<IAstUnion, TypeUnionModel>(UnionModeller.Factory)
      // Object
      .AddModeller<IAstTypeParam, TypeParamModel>(TypeParamModeller.Factory)
      .AddModeller<IAstTypeArg, TypeArgModel>(TypeArgModeller.Factory)
      .AddModeller<IAstObjBase, ObjBaseModel>(ObjBaseModeller.Factory)
      .AddModeller<IAstAlternate, AlternateModel>(AlternateModeller.Factory)
      // Dual
      .AddModeller<IAstDualField, DualFieldModel>(DualFieldModeller.Factory)
      .AddTypeModeller<IAstObject<IAstDualField>, TypeDualModel>(DualModeller.Factory)
      // Input
      .AddModeller<IAstInputField, InputFieldModel>(InputFieldModeller.Factory)
      .AddTypeModeller<IAstObject<IAstInputField>, TypeInputModel>(InputModeller.Factory)
      .AddModeller<IAstInputParam, InputParamModel>(InputParamModeller.Factory)
      // Output
      .AddModeller<IAstOutputField, OutputFieldModel>(OutputFieldModeller.Factory)
      .AddTypeModeller<IAstObject<IAstOutputField>, TypeOutputModel>(OutputModeller.Factory);
}
