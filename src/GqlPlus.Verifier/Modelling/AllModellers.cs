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
      .AddModeller<CategoryDeclAst, CategoryModeller>()
      .AddModeller<ConstantAst, ConstantModeller>()
      .AddModeller<EnumDeclAst, EnumModeller>()
      .AddModeller<FieldKeyAst, SimpleModeller>()
      .AddModeller<InputDeclAst, InputModeller>()
      .AddModeller<InputReferenceAst, InputReferenceModeller>()
      .AddModeller<ModifierAst, ModifierModeller>()
      .AddModeller<OptionSettingAst, SettingModeller>()
      .AddModeller<OutputDeclAst, OutputModeller>()
      .AddModeller<OutputReferenceAst, OutputReferenceModeller>()
      .AddModeller<ParameterAst, ParameterModeller>()
    ;

  public static IServiceCollection AddModeller<TAst, TModeller>(this IServiceCollection services)
    where TAst : AstBase
    where TModeller : class, IModeller<TAst>
    => services.AddSingleton<IModeller<TAst>, TModeller>();

  public static IServiceCollection AddAlternateModeller<TRefAst, TBase>(this IServiceCollection services)
    where TRefAst : AstReference<TRefAst>
    where TBase : ITypeBaseModel
    => services.AddModeller<AstAlternate<TRefAst>, AlternateModeller<TRefAst, TBase>>();
}
