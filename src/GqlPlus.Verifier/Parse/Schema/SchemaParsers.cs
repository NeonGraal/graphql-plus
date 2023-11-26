using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Schema;

public static class SchemaParsers
{
  public static IServiceCollection AddSchemaParsers(this IServiceCollection services)
    => services
      .AddSingleton<CategoryName>()
      .AddSingleton<IParser<NullAst>, ParseNull>()
      .AddSingleton<IParser<CategoryOption>, ParseCategoryOption>()
      .AddSingleton<IParser<CategoryOutput>, ParseCategoryDefinition>()
      .AddSingleton<IParser<CategoryAst>, ParseCategory>()
      .AddSingleton<DirectiveName>()
      .AddSingleton<IParser<ParameterAst>, ParseParameter>()
      .AddSingleton<IParser<DirectiveOption>, ParseDirectiveOption>()
      .AddSingleton<IParser<DirectiveLocation>, ParseDirectiveDefinition>()
      .AddSingleton<IParser<DirectiveAst>, ParseDirective>()
      ;
}
