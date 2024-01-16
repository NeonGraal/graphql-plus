using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Modelling;

internal static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
    => services
      .AddSingleton<IModeller<CategoryDeclAst>, CategoryModeller>()
      .AddSingleton<IModeller<ConstantAst>, ConstantModeller>()
      .AddSingleton<IModeller<EnumDeclAst>, EnumModeller>()
      .AddSingleton<IModeller<FieldKeyAst>, SimpleModeller>()
      .AddSingleton<IModeller<ModifierAst>, ModifierModeller>()
      .AddSingleton<IModeller<OptionSettingAst>, SettingModeller>()
      .AddSingleton<IModeller<ParameterAst>, ParameterModeller>()
    ;
}
