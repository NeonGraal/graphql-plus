﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Ast.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Modelling;

internal static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
    => services
      .AddAlternateModeller<DualReferenceAst, DualBaseModel>()
      .AddAlternateModeller<InputReferenceAst, InputBaseModel>()
      .AddAlternateModeller<OutputReferenceAst, OutputBaseModel>()
      .AddModeller<CategoryDeclAst, CategoryModel, CategoryModeller>()
      .AddModeller<ConstantAst, ConstantModel, ConstantModeller>()
      .AddModeller<DirectiveDeclAst, DirectiveModel, DirectiveModeller>()
      .AddModeller<DualFieldAst, DualFieldModel, DualFieldModeller>()
      .AddModeller<DualReferenceAst, DualBaseModel, DualReferenceModeller>()
      .AddModeller<FieldKeyAst, SimpleModel, SimpleModeller>()
      .AddModeller<InputFieldAst, InputFieldModel, InputFieldModeller>()
      .AddModeller<InputReferenceAst, InputBaseModel, InputReferenceModeller>()
      .AddModeller<OptionSettingAst, SettingModel, SettingModeller>()
      .AddModeller<OutputFieldAst, OutputFieldModel, OutputFieldModeller>()
      .AddModeller<OutputReferenceAst, OutputBaseModel, OutputReferenceModeller>()
      .AddModeller<ParameterAst, ParameterModel, ParameterModeller>()
      .AddModeller<SchemaAst, SchemaModel, SchemaModeller>()
      .AddModifierModeller()
      .AddDomainModeller<DomainTrueFalseAst, DomainTrueFalseModel, DomainBooleanModeller>()
      .AddDomainModeller<DomainMemberAst, DomainMemberModel, DomainEnumModeller>()
      .AddDomainModeller<DomainRangeAst, DomainRangeModel, DomainNumberModeller>()
      .AddDomainModeller<DomainRegexAst, DomainRegexModel, DomainStringModeller>()
      .AddTypeModeller<DualDeclAst, TypeDualModel, DualModeller>()
      .AddTypeModeller<EnumDeclAst, TypeEnumModel, EnumModeller>()
      .AddTypeModeller<InputDeclAst, TypeInputModel, InputModeller>()
      .AddTypeModeller<OutputDeclAst, TypeOutputModel, OutputModeller>()
      .AddTypeModeller<UnionDeclAst, TypeUnionModel, UnionModeller>()
      .AddTypesModeller()
    ;

  public static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : AstBase
    where TModeller : class, IModeller<TAst, TModel>
    => services.AddSingleton<IModeller<TAst, TModel>, TModeller>();

  public static IServiceCollection AddTypesModeller(this IServiceCollection services)
    => services
      .AddSingleton<ITypesModeller, TypeModeller>()
      .AddSingleton<IModeller<AstType, BaseTypeModel>>(c => c.GetRequiredService<ITypesModeller>());

  public static IServiceCollection AddTypeModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : AstBase
    where TModeller : class, IModeller<TAst, TModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddSingleton<IModeller<TAst, TModel>, TModeller>(c => c.GetRequiredService<TModeller>())
      .AddSingleton<ITypeModeller, TModeller>(c => c.GetRequiredService<TModeller>());

  public static IServiceCollection AddDomainModeller<TItemAst, TItemModel, TModeller>(this IServiceCollection services)
    where TItemAst : AstAbbreviated, IAstDomainItem
    where TItemModel : IBaseDomainItemModel
    where TModeller : class, IDomainModeller<TItemAst, TItemModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddSingleton<IDomainModeller<TItemAst, TItemModel>, TModeller>(c => c.GetRequiredService<TModeller>())
      .AddSingleton<ITypeModeller, TModeller>(c => c.GetRequiredService<TModeller>());

  public static IServiceCollection AddModifierModeller(this IServiceCollection services)
    => services
      .AddSingleton<IModifierModeller, ModifierModeller>()
      .AddSingleton<IModeller<ModifierAst, ModifierModel>>(c => c.GetRequiredService<IModifierModeller>())
      .AddSingleton<IModeller<ModifierAst, CollectionModel>>(c => c.GetRequiredService<IModifierModeller>());

  public static IServiceCollection AddAlternateModeller<TRefAst, TBase>(this IServiceCollection services)
    where TRefAst : AstReference<TRefAst>
    where TBase : IObjBaseModel
    => services.AddSingleton<IAlternateModeller<TRefAst, TBase>, AlternateModeller<TRefAst, TBase>>();
}
