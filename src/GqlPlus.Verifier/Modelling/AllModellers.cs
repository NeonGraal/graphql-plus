using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Modelling;

internal static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
    => services
      .AddAlternateModeller<InputReferenceAst, InputBaseModel>()
      .AddAlternateModeller<OutputReferenceAst, OutputBaseModel>()
      .AddModeller<CategoryDeclAst, CategoryModel, CategoryModeller>()
      .AddModeller<ConstantAst, ConstantModel, ConstantModeller>()
      .AddModeller<DirectiveDeclAst, DirectiveModel, DirectiveModeller>()
      .AddModeller<EnumDeclAst, TypeEnumModel, EnumModeller>()
      .AddModeller<FieldKeyAst, SimpleModel, SimpleModeller>()
      .AddModeller<InputDeclAst, TypeInputModel, InputModeller>()
      .AddModeller<InputReferenceAst, InputBaseModel, InputReferenceModeller>()
      .AddModeller<ModifierAst, ModifierModel, ModifierModeller>()
      .AddModeller<ModifierAst, CollectionModel, ModifierModeller>()
      .AddModeller<OptionSettingAst, SettingModel, SettingModeller>()
      .AddModeller<OutputDeclAst, TypeOutputModel, OutputModeller>()
      .AddModeller<OutputReferenceAst, OutputBaseModel, OutputReferenceModeller>()
      .AddModeller<ParameterAst, ParameterModel, ParameterModeller>()
    ;

  public static IServiceCollection AddModeller<TAst, TModel, TModeller>(this IServiceCollection services)
    where TAst : AstBase
    where TModeller : class, IModeller<TAst, TModel>
    => services.AddSingleton<IModeller<TAst, TModel>, TModeller>();

  public static IServiceCollection AddAlternateModeller<TRefAst, TBase>(this IServiceCollection services)
    where TRefAst : AstReference<TRefAst>
    where TBase : IObjBaseModel
    => services.AddModeller<AstAlternate<TRefAst>, AlternateModel<TBase>, AlternateModeller<TRefAst, TBase>>();
}
