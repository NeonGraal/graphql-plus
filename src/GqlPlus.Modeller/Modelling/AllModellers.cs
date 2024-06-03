﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

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
      .AddDomainModeller<IGqlpDomainMember, DomainMemberModel, DomainEnumModeller>()
      .AddDomainModeller<IGqlpDomainRange, DomainRangeModel, DomainNumberModeller>()
      .AddDomainModeller<IGqlpDomainRegex, DomainRegexModel, DomainStringModeller>()
      .AddDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel, DomainBooleanModeller>()
      .AddTypeModeller<IGqlpEnum, TypeEnumModel, EnumModeller>()
      .AddTypeModeller<IGqlpUnion, TypeUnionModel, UnionModeller>()
      // Object
      .AddAlternateModeller<IGqlpDualBase, DualBaseModel>()
      .AddAlternateModeller<IGqlpInputBase, InputBaseModel>()
      .AddAlternateModeller<IGqlpOutputBase, OutputBaseModel>()
      .AddModeller<IGqlpDualBase, DualBaseModel, DualBaseModeller>()
      .AddModeller<IGqlpDualField, DualFieldModel, DualFieldModeller>()
      .AddModeller<IGqlpInputBase, InputBaseModel, InputBaseModeller>()
      .AddModeller<IGqlpInputField, InputFieldModel, InputFieldModeller>()
      .AddModeller<IGqlpInputParameter, InputParameterModel, InputParameterModeller>()
      .AddModeller<IGqlpOutputBase, OutputBaseModel, OutputBaseModeller>()
      .AddModeller<IGqlpOutputField, OutputFieldModel, OutputFieldModeller>()
      .AddTypeModeller<IGqlpDualObject, TypeDualModel, DualModeller>()
      .AddTypeModeller<IGqlpInputObject, TypeInputModel, InputModeller>()
      .AddTypeModeller<IGqlpOutputObject, TypeOutputModel, OutputModeller>()
    ;

  private static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IRendering
    where TModeller : class, IModeller<TAst, TModel>
    => services.AddSingleton<IModeller<TAst, TModel>, TModeller>();

  private static IServiceCollection AddTypesModeller(this IServiceCollection services)
    => services
      .AddSingleton<ITypesModeller, TypesModeller>()
      .AddProvider<ITypesModeller, IModeller<IGqlpType, BaseTypeModel>>();

  private static IServiceCollection AddTypeModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IRendering
    where TModeller : class, IModeller<TAst, TModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddProvider<TModeller, IModeller<TAst, TModel>>()
      .AddProvider<TModeller, ITypeModeller>();

  private static IServiceCollection AddDomainModeller<TItemAst, TItemModel, TModeller>(this IServiceCollection services)
    where TItemAst : IGqlpDomainItem
    where TItemModel : IBaseDomainItemModel
    where TModeller : class, IDomainModeller<TItemAst, TItemModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddProvider<TModeller, IDomainModeller<TItemAst, TItemModel>>()
      .AddProvider<TModeller, ITypeModeller>();

  private static IServiceCollection AddModifierModeller(this IServiceCollection services)
    => services
      .AddSingleton<IModifierModeller, ModifierModeller>()
      .AddProvider<IModifierModeller, IModeller<IGqlpModifier, ModifierModel>>()
      .AddProvider<IModifierModeller, IModeller<IGqlpModifier, CollectionModel>>();

  private static IServiceCollection AddAlternateModeller<TObjBaseAst, TObjBase>(this IServiceCollection services)
    where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>, IEquatable<TObjBaseAst>
    where TObjBase : IObjBaseModel
    => services.AddSingleton<IAlternateModeller<TObjBaseAst, TObjBase>, AlternateModeller<TObjBaseAst, TObjBase>>();
}
