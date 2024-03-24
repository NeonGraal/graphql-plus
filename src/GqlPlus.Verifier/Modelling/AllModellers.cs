using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
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
      .AddModeller<DualDeclAst, TypeDualModel, DualModeller>()
      .AddModeller<DualFieldAst, DualFieldModel, DualFieldModeller>()
      .AddModeller<DualReferenceAst, DualBaseModel, DualReferenceModeller>()
      .AddModeller<EnumDeclAst, TypeEnumModel, EnumModeller>()
      .AddModeller<FieldKeyAst, SimpleModel, SimpleModeller>()
      .AddModeller<InputDeclAst, TypeInputModel, InputModeller>()
      .AddModeller<InputFieldAst, InputFieldModel, InputFieldModeller>()
      .AddModeller<InputReferenceAst, InputBaseModel, InputReferenceModeller>()
      .AddModeller<OptionSettingAst, SettingModel, SettingModeller>()
      .AddModeller<OutputDeclAst, TypeOutputModel, OutputModeller>()
      .AddModeller<OutputFieldAst, OutputFieldModel, OutputFieldModeller>()
      .AddModeller<OutputReferenceAst, OutputBaseModel, OutputReferenceModeller>()
      .AddModeller<ParameterAst, ParameterModel, ParameterModeller>()
      .AddModeller<UnionDeclAst, TypeUnionModel, UnionModeller>()
      .AddModifierModeller()
    ;

  public static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : AstBase
    where TModeller : class, IModeller<TAst, TModel>
    => services.AddSingleton<IModeller<TAst, TModel>, TModeller>();

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
