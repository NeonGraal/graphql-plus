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
      .AddSingleton<ICategoryName, CategoryName>()
      .AddOption<CategoryOption>()
      .AddParser<CategoryOutput, ParseCategoryDefinition>()
      .AddDeclarationParser<CategoryDeclAst, ParseCategory>("category")
      // Directive
      .AddSingleton<IDirectiveName, DirectiveName>()
      .AddOption<DirectiveOption>()
      .AddParser<DirectiveLocation, ParseDirectiveDefinition>()
      .AddDeclarationParser<DirectiveDeclAst, ParseDirective>("directive")
      // Option
      .AddParser<OptionDefinition, ParseOptionDefinition>()
      .AddParser<OptionSettingAst, ParseOptionSetting>()
      .AddDeclarationParser<OptionDeclAst, ParseOption>("option")
      // Types
      .AddSingleton<ISimpleName, SimpleName>()
      // Enum
      .AddParser<EnumDefinition, ParseEnumDefinition>()
      .AddParser<EnumValueAst, ParseEnumValue>()
      .AddDeclarationParser<EnumDeclAst, ParseEnum>("enum")
      // Scalar
      .AddParser<ScalarDefinition, ParseScalarDefinition>()
      .AddArrayParser<ScalarRangeAst, ParseScalarRange>()
      .AddArrayParser<ScalarRegexAst, ParseScalarRegex>()
      .AddArrayParser<ScalarReferenceAst, ParseScalarReference>()
      .AddDeclarationParser<ScalarDeclAst, ParseScalar>("scalar")
      // Objects
      .AddParserArray<TypeParameterAst, ParseTypeParameters>()
      // Input
      .AddParser<InputReferenceAst, ParseInputReference>()
      .AddParser<InputFieldAst, ParseInputField>()
      .AddDeclarationParser<InputDeclAst, ParseInput>("input")
      .AddObjectParser<ParseInputDefinition, InputFieldAst, InputReferenceAst>()
      // Output
      .AddParser<OutputReferenceAst, ParseOutputReference>()
      .AddParser<OutputFieldAst, ParseOutputField>()
      .AddDeclarationParser<OutputDeclAst, ParseOutput>("output")
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

  public static IServiceCollection AddDeclarationParser<D, P>(this IServiceCollection services, string selector)
    where D : AstDeclaration
    where P : class, Parser<D>.I
    => services
      .AddParser<D, P>()
      .AddSingleton<IParseDeclaration>(c => new ParseDeclaration<D>(selector, c.GetRequiredService<Parser<D>.D>()))
    ;
}
