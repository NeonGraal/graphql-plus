using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
    => services
      .AddAlternateModeller<DualBaseAst, DualBaseModel>()
      .AddAlternateModeller<InputBaseAst, InputBaseModel>()
      .AddAlternateModeller<OutputBaseAst, OutputBaseModel>()
      .AddModeller<IGqlpSchemaCategory, CategoryModel, CategoryModeller>()
      .AddModeller<ConstantAst, ConstantModel, ConstantModeller>()
      .AddModeller<IGqlpSchemaDirective, DirectiveModel, DirectiveModeller>()
      .AddModeller<DualFieldAst, DualFieldModel, DualFieldModeller>()
      .AddModeller<DualBaseAst, DualBaseModel, DualBaseModeller>()
      .AddModeller<FieldKeyAst, SimpleModel, SimpleModeller>()
      .AddModeller<InputFieldAst, InputFieldModel, InputFieldModeller>()
      .AddModeller<InputBaseAst, InputBaseModel, InputBaseModeller>()
      .AddModeller<OptionSettingAst, SettingModel, SettingModeller>()
      .AddModeller<OutputFieldAst, OutputFieldModel, OutputFieldModeller>()
      .AddModeller<OutputBaseAst, OutputBaseModel, OutputBaseModeller>()
      .AddModeller<ParameterAst, ParameterModel, ParameterModeller>()
      .AddModeller<IGqlpSchema, SchemaModel, SchemaModeller>()
      .AddModifierModeller()
      .AddDomainModeller<DomainTrueFalseAst, DomainTrueFalseModel, DomainBooleanModeller>()
      .AddDomainModeller<DomainMemberAst, DomainMemberModel, DomainEnumModeller>()
      .AddDomainModeller<DomainRangeAst, DomainRangeModel, DomainNumberModeller>()
      .AddDomainModeller<DomainRegexAst, DomainRegexModel, DomainStringModeller>()
      .AddTypeModeller<DualDeclAst, TypeDualModel, DualModeller>()
      .AddTypeModeller<IGqlpEnum, TypeEnumModel, EnumModeller>()
      .AddTypeModeller<InputDeclAst, TypeInputModel, InputModeller>()
      .AddTypeModeller<OutputDeclAst, TypeOutputModel, OutputModeller>()
      .AddTypeModeller<IGqlpUnion, TypeUnionModel, UnionModeller>()
      .AddTypesModeller()
    ;

  private static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IRendering
    where TModeller : class, IModeller<TAst, TModel>
    => services.AddSingleton<IModeller<TAst, TModel>, TModeller>();

  private static IServiceCollection AddTypesModeller(this IServiceCollection services)
    => services
      .AddSingleton<ITypesModeller, TypeModeller>()
      .AddSingleton<IModeller<IGqlpType, BaseTypeModel>>(c => c.GetRequiredService<ITypesModeller>());

  private static IServiceCollection AddTypeModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IRendering
    where TModeller : class, IModeller<TAst, TModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddSingleton<IModeller<TAst, TModel>, TModeller>(c => c.GetRequiredService<TModeller>())
      .AddSingleton<ITypeModeller, TModeller>(c => c.GetRequiredService<TModeller>());

  private static IServiceCollection AddDomainModeller<TItemAst, TItemModel, TModeller>(this IServiceCollection services)
    where TItemAst : AstAbbreviated, IGqlpDomainItem
    where TItemModel : IBaseDomainItemModel
    where TModeller : class, IDomainModeller<TItemAst, TItemModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddSingleton<IDomainModeller<TItemAst, TItemModel>, TModeller>(c => c.GetRequiredService<TModeller>())
      .AddSingleton<ITypeModeller, TModeller>(c => c.GetRequiredService<TModeller>());

  private static IServiceCollection AddModifierModeller(this IServiceCollection services)
    => services
      .AddSingleton<IModifierModeller, ModifierModeller>()
      .AddSingleton<IModeller<ModifierAst, ModifierModel>>(c => c.GetRequiredService<IModifierModeller>())
      .AddSingleton<IModeller<ModifierAst, CollectionModel>>(c => c.GetRequiredService<IModifierModeller>());

  private static IServiceCollection AddAlternateModeller<TObjBaseAst, TObjBase>(this IServiceCollection services)
    where TObjBaseAst : AstObjectBase<TObjBaseAst>
    where TObjBase : IObjBaseModel
    => services.AddSingleton<IAlternateModeller<TObjBaseAst, TObjBase>, AlternateModeller<TObjBaseAst, TObjBase>>();
}
