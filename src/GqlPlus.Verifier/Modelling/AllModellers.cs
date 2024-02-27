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
      .AddSingleton<IModeller<CategoryDeclAst>, CategoryModeller>()
      .AddSingleton<IModeller<ConstantAst>, ConstantModeller>()
      .AddSingleton<IModeller<EnumDeclAst>, EnumModeller>()
      .AddSingleton<IModeller<FieldKeyAst>, SimpleModeller>()
      .AddSingleton<IModeller<InputDeclAst>, InputModeller>()
      .AddSingleton<IModeller<InputReferenceAst>, InputReferenceModeller>()
      .AddSingleton<IModeller<ModifierAst>, ModifierModeller>()
      .AddSingleton<IModeller<OptionSettingAst>, SettingModeller>()
      .AddSingleton<IModeller<OutputDeclAst>, OutputModeller>()
      .AddSingleton<IModeller<OutputReferenceAst>, OutputReferenceModeller>()
      .AddSingleton<IModeller<ParameterAst>, ParameterModeller>()
    ;
  public static IServiceCollection AddAlternateModeller<TRefAst, TBase>(this IServiceCollection services)
    where TRefAst : AstReference<TRefAst>
    where TBase : ITypeBaseModel
    => services.AddSingleton<IModeller<AstAlternate<TRefAst>>, AlternateModeller<TRefAst, TBase>>();
}
