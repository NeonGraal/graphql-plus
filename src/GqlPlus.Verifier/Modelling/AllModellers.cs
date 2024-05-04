using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

internal static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
    => services
      .AddAlternateModeller<DualBaseAst, DualBaseModel>()
      .AddAlternateModeller<InputBaseAst, InputBaseModel>()
      .AddAlternateModeller<OutputBaseAst, OutputBaseModel>()
      .AddModeller<IGqlpSchemaCategory, CategoryModel, CategoryModeller>()
      .AddModeller<ConstantAst, ConstantModel, ConstantModeller>()
      .AddModeller<DirectiveDeclAst, DirectiveModel, DirectiveModeller>()
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
      .AddTypeModeller<EnumDeclAst, TypeEnumModel, EnumModeller>()
      .AddTypeModeller<InputDeclAst, TypeInputModel, InputModeller>()
      .AddTypeModeller<OutputDeclAst, TypeOutputModel, OutputModeller>()
      .AddTypeModeller<UnionDeclAst, TypeUnionModel, UnionModeller>()
      .AddTypesModeller()
    ;

  public static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
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
    where TItemAst : AstAbbreviated, IGqlpDomainItem
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

  public static IServiceCollection AddAlternateModeller<TObjBaseAst, TObjBase>(this IServiceCollection services)
    where TObjBaseAst : AstObjectBase<TObjBaseAst>
    where TObjBase : IObjBaseModel
    => services.AddSingleton<IAlternateModeller<TObjBaseAst, TObjBase>, AlternateModeller<TObjBaseAst, TObjBase>>();
}
