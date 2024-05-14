using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
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
      .AddAlternateModeller<DualBaseAst, DualBaseModel>()
      .AddAlternateModeller<InputBaseAst, InputBaseModel>()
      .AddAlternateModeller<OutputBaseAst, OutputBaseModel>()
      .AddModeller<DualBaseAst, DualBaseModel, DualBaseModeller>()
      .AddModeller<DualFieldAst, DualFieldModel, DualFieldModeller>()
      .AddModeller<InputBaseAst, InputBaseModel, InputBaseModeller>()
      .AddModeller<InputFieldAst, InputFieldModel, InputFieldModeller>()
      .AddModeller<InputParameterAst, InputParameterModel, InputParameterModeller>()
      .AddModeller<OutputBaseAst, OutputBaseModel, OutputBaseModeller>()
      .AddModeller<OutputFieldAst, OutputFieldModel, OutputFieldModeller>()
      .AddTypeModeller<DualDeclAst, TypeDualModel, DualModeller>()
      .AddTypeModeller<InputDeclAst, TypeInputModel, InputModeller>()
      .AddTypeModeller<OutputDeclAst, TypeOutputModel, OutputModeller>()
    ;

  private static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IRendering
    where TModeller : class, IModeller<TAst, TModel>
    => services.AddSingleton<IModeller<TAst, TModel>, TModeller>();

  private static IServiceCollection AddTypesModeller(this IServiceCollection services)
    => services
      .AddSingleton<ITypesModeller, TypesModeller>()
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
    where TItemAst : IGqlpDomainItem
    where TItemModel : IBaseDomainItemModel
    where TModeller : class, IDomainModeller<TItemAst, TItemModel>, ITypeModeller
    => services
      .AddSingleton<TModeller>()
      .AddSingleton<IDomainModeller<TItemAst, TItemModel>, TModeller>(c => c.GetRequiredService<TModeller>())
      .AddSingleton<ITypeModeller, TModeller>(c => c.GetRequiredService<TModeller>());

  private static IServiceCollection AddModifierModeller(this IServiceCollection services)
    => services
      .AddSingleton<IModifierModeller, ModifierModeller>()
      .AddSingleton<IModeller<IGqlpModifier, ModifierModel>>(c => c.GetRequiredService<IModifierModeller>())
      .AddSingleton<IModeller<IGqlpModifier, CollectionModel>>(c => c.GetRequiredService<IModifierModeller>());

  private static IServiceCollection AddAlternateModeller<TObjBaseAst, TObjBase>(this IServiceCollection services)
    where TObjBaseAst : AstObjectBase<TObjBaseAst>
    where TObjBase : IObjBaseModel
    => services.AddSingleton<IAlternateModeller<TObjBaseAst, TObjBase>, AlternateModeller<TObjBaseAst, TObjBase>>();
}
