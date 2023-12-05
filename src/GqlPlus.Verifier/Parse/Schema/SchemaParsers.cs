using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Schema;

public static class SchemaParsers
{
  public static IServiceCollection AddSchemaParsers(this IServiceCollection services)
    => services
      .AddParser<NullAst, ParseNull>()
      .AddParserArray<NullAst, ParseNulls>()
      .AddParserArray<ParameterAst, ParseParameters>()
      .AddParserArray<string, ParseAliases>()
      // Category
      .AddSingleton<CategoryName>()
      .AddOption<CategoryOption>()
      .AddParser<CategoryOutput, ParseCategoryDefinition>()
      .AddParser<CategoryAst, ParseCategory>()
      // Directive
      .AddSingleton<DirectiveName>()
      .AddOption<DirectiveOption>()
      .AddParser<DirectiveLocation, ParseDirectiveDefinition>()
      .AddParser<DirectiveAst, ParseDirective>()
      // Types
      .AddSingleton<TypeName>()
      // Enum
      .AddParser<EnumDefinition, ParseEnumDefinition>()
      .AddParser<EnumLabelAst, ParseEnumLabel>()
      .AddParser<EnumAst, ParseEnum>()
      // Scalar
      .AddParser<ScalarDefinition, ParseScalarDefinition>()
      .AddParser<ScalarRangeAst, ParseScalarRange>()
      .AddParserArray<ScalarRangeAst, ArrayParser<ScalarRangeAst>>()
      .AddParser<ScalarRegexAst, ParseScalarRegex>()
      .AddParserArray<ScalarRegexAst, ArrayParser<ScalarRegexAst>>()
      .AddParser<ScalarAst, ParseScalar>()
      // Objects
      .AddParserArray<TypeParameterAst, ParseTypeParameters>()
      // Input
      .AddParser<InputReferenceAst, ParseInputReference>()
      .AddParser<InputFieldAst, ParseInputField>()
      .AddParser<InputAst, ParseInput>()
      .AddObjectParser<ParseInputDefinition, InputFieldAst, InputReferenceAst>()
      // Output
      .AddParser<OutputReferenceAst, ParseOutputReference>()
      .AddParser<OutputFieldAst, ParseOutputField>()
      .AddParser<OutputAst, ParseOutput>()
      .AddObjectParser<ParseOutputDefinition, OutputFieldAst, OutputReferenceAst>()
      // Schema
      .AddParser<SchemaAst, ParseSchema>()
      ;

  public static IServiceCollection AddOption<O>(this IServiceCollection services)
    where O : struct
    => services.AddParser<O, OptionParser<O>>();

  public static IServiceCollection AddObjectParser<D, F, R>(this IServiceCollection services)
    where D : ParseObjectDefinition<F, R>
    where F : AstField<R>
    where R : AstReference<R>
    => services.AddParser<ObjectDefinition<F, R>, D>();
}
