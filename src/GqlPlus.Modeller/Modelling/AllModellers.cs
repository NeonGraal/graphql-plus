using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
    => services
      .AddModeller<IGqlpConstant, ConstantModel, ConstantModeller>()
      .AddModeller<IGqlpFieldKey, SimpleModel, SimpleModeller>()
      .AddModifierModeller()
      // Schema
      .AddModeller<IGqlpSchema, SchemaModel, SchemaModeller>()
      .AddModeller<IGqlpSchemaCategory, CategoryModel, CategoryModeller>()
      .AddModeller<IGqlpSchemaDirective, DirectiveModel, DirectiveModeller>()
      .AddModeller<IGqlpSchemaSetting, SettingModel, SettingModeller>()
      // Types
      .AddTypesModeller()
      .AddTypeModeller<IGqlpTypeSpecial, SpecialTypeModel, SpecialTypeModeller>()
      // Simple
      .AddDomainModeller<IGqlpDomainLabel, DomainLabelModel, DomainEnumModeller>()
      .AddDomainModeller<IGqlpDomainRange, DomainRangeModel, DomainNumberModeller>()
      .AddDomainModeller<IGqlpDomainRegex, DomainRegexModel, DomainStringModeller>()
      .AddDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel, DomainBooleanModeller>()
      .AddTypeModeller<IGqlpEnum, TypeEnumModel, EnumModeller>()
      .AddTypeModeller<IGqlpUnion, TypeUnionModel, UnionModeller>()
      // Object
      .AddModeller<IGqlpDualArg, DualArgModel, DualArgModeller>()
      .AddModeller<IGqlpDualBase, DualBaseModel, DualBaseModeller>()
      .AddModeller<IGqlpDualField, DualFieldModel, DualFieldModeller>()
      .AddModeller<IGqlpDualAlternate, DualAlternateModel, DualAlternateModeller>()
      .AddModeller<IGqlpInputArg, InputArgModel, InputArgModeller>()
      .AddModeller<IGqlpInputBase, InputBaseModel, InputBaseModeller>()
      .AddModeller<IGqlpInputField, InputFieldModel, InputFieldModeller>()
      .AddModeller<IGqlpInputAlternate, InputAlternateModel, InputAlternateModeller>()
      .AddModeller<IGqlpInputParam, InputParamModel, InputParamModeller>()
      .AddModeller<IGqlpOutputArg, OutputArgModel, OutputArgModeller>()
      .AddModeller<IGqlpOutputBase, OutputBaseModel, OutputBaseModeller>()
      .AddModeller<IGqlpOutputField, OutputFieldModel, OutputFieldModeller>()
      .AddModeller<IGqlpOutputAlternate, OutputAlternateModel, OutputAlternateModeller>()
      .AddTypeModeller<IGqlpDualObject, TypeDualModel, DualModeller>()
      .AddTypeModeller<IGqlpInputObject, TypeInputModel, InputModeller>()
      .AddTypeModeller<IGqlpOutputObject, TypeOutputModel, OutputModeller>()
    ;

  private static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IModelBase
    where TModeller : class, IModeller<TAst, TModel>
    => services
      .AddSingleton<TModeller>()
      .AddProvider<TModeller, IModeller<TAst>>()
      .AddProvider<TModeller, IModeller<TAst, TModel>>();

  private static IServiceCollection AddTypesModeller(this IServiceCollection services)
    => services
      .AddSingleton<ITypesModeller, TypesModeller>()
      .AddProvider<ITypesModeller, IModeller<IGqlpType, BaseTypeModel>>();

  private static IServiceCollection AddTypeModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IModelBase
    where TModeller : class, IModeller<TAst, TModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddProvider<TModeller, IModeller<TAst>>()
      .AddProvider<TModeller, IModeller<TAst, TModel>>()
      .AddProvider<TModeller, ITypeModeller>();

  private static IServiceCollection AddDomainModeller<TItemAst, TItemModel, TModeller>(this IServiceCollection services)
    where TItemAst : IGqlpDomainItem
    where TItemModel : BaseDomainItemModel
    where TModeller : class, IDomainModeller<TItemAst, TItemModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddProvider<TModeller, IDomainModeller<TItemAst, TItemModel>>()
      .AddProvider<TModeller, ITypeModeller>();

  private static IServiceCollection AddModifierModeller(this IServiceCollection services)
    => services
      .AddSingleton<IModifierModeller, ModifierModeller>()
      .AddProvider<IModifierModeller, IModeller<IGqlpModifier>>()
      .AddProvider<IModifierModeller, IModeller<IGqlpModifier, ModifierModel>>()
      .AddProvider<IModifierModeller, IModeller<IGqlpModifier, CollectionModel>>();
}
