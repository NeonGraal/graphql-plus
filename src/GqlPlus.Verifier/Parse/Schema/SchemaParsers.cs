using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Schema;

public static class SchemaParsers
{
  public static IServiceCollection AddSchemaParsers(this IServiceCollection services)
    => services
      .AddNullParsers()
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
      .AddEnum<DirectiveLocation>()
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
      .AddParser<EnumMemberAst, ParseEnumMember>()
      .AddDeclarationParser<EnumDeclAst, ParseEnum>("enum")
      // Scalar
      .AddParser<ScalarDefinition, ParseScalarDefinition>()
      .AddEnum<ScalarKind>()
      .AddScalarParser<ScalarFalseAst, ParseScalarFalse>()
      .AddScalarParser<ScalarMemberAst, ParseScalarMember>()
      .AddScalarParser<ScalarRangeAst, ParseScalarRange>()
      .AddScalarParser<ScalarRegexAst, ParseScalarRegex>()
      .AddScalarParser<ScalarReferenceAst, ParseScalarReference>()
      .AddDeclarationParser<AstScalar, ParseScalar>("scalar")
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

  public static IServiceCollection AddEnum<E>(this IServiceCollection services)
    where E : struct
    => services.AddParser<IEnumParser<E>, E, EnumParser<E>>();

  public static IServiceCollection AddOption<O>(this IServiceCollection services)
    where O : struct
    => services
      .AddParser<IOptionParser<O>, O, OptionParser<O>>()
      .AddParser<IEnumParser<O>, O, EnumParser<O>>();

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
      .AddSingleton<IParseDeclaration>(c => new ParseDeclaration<D>(selector, c.GetRequiredService<Parser<D>.D>()));

  public static IServiceCollection AddScalarParser<S, P>(this IServiceCollection services)
    where P : class, Parser<S>.I, IParseScalar
    => services
      .AddArrayParser<S, P>()
      .AddSingleton<IParseScalar>(c => c.GetRequiredService<P>());

  public static IServiceCollection AddNullParsers(this IServiceCollection services)
    => services
      .AddParser<NullAst, ParseNull>()
      .AddParserArray<NullAst, ParseNulls>()
      .AddParser<IOptionParser<NullOption>, NullOption, ParseNullOption>()
      .AddParser<IEnumParser<NullOption>, NullOption, ParseNullOption>();
}
