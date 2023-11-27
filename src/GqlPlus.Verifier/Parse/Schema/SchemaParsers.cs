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
      .AddSingleton<IParser<ParameterAst>, ParseParameter>()
      .AddSingleton<IParserArray<string>, ParseAliases>()
      .AddSingleton<TypeName>()
      // Category
      .AddSingleton<IParser<CategoryOption>, ParseCategoryOption>()
      .AddSingleton<IParser<CategoryOutput>, ParseCategoryDefinition>()
      .AddSingleton<IParser<CategoryAst>, ParseCategory>()
      // Directive
      .AddSingleton<DirectiveName>()
      .AddSingleton<IParser<DirectiveOption>, ParseDirectiveOption>()
      .AddSingleton<IParser<DirectiveLocation>, ParseDirectiveDefinition>()
      .AddSingleton<IParser<DirectiveAst>, ParseDirective>()
      // Enum
      .AddSingleton<IParser<EnumDefinition>, ParseEnumDefinition>()
      .AddSingleton<IParser<EnumLabelAst>, ParseEnumLabel>()
      .AddSingleton<IParser<EnumAst>, ParseEnum>()
      ;
}
