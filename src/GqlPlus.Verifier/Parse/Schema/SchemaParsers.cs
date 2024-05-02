using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Parse.Schema.Globals;
using GqlPlus.Verifier.Parse.Schema.Objects;
using GqlPlus.Verifier.Parse.Schema.Simple;
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
      // Domain
      .AddParser<DomainDefinition, ParseDomainDefinition>()
      .AddEnum<DomainKind>()
      .AddDomainParser<DomainTrueFalseAst, ParseDomainTrueFalse>()
      .AddDomainParser<DomainMemberAst, ParseDomainMember>()
      .AddDomainParser<DomainRangeAst, ParseDomainRange>()
      .AddDomainParser<DomainRegexAst, ParseDomainRegex>()
      .AddDeclarationParser<AstDomain, ParseDomain>("domain")
      // Union
      .AddParser<UnionDefinition, ParseUnionDefinition>()
      .AddParser<UnionMemberAst, ParseUnionMember>()
      .AddDeclarationParser<UnionDeclAst, ParseUnion>("union")
      // Objects
      .AddParserArray<TypeParameterAst, ParseTypeParameters>()
      // Dual
      .AddParser<DualReferenceAst, ParseDualReference>()
      .AddParser<DualFieldAst, ParseDualField>()
      .AddDeclarationParser<DualDeclAst, ParseDual>("dual")
      .AddObjectParser<ParseDualDefinition, DualFieldAst, DualReferenceAst>()
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

  public static IServiceCollection AddEnum<TEnum>(this IServiceCollection services)
    where TEnum : struct
    => services.AddParser<IEnumParser<TEnum>, TEnum, EnumParser<TEnum>>();

  public static IServiceCollection AddOption<TOption>(this IServiceCollection services)
    where TOption : struct
    => services
      .AddParser<IOptionParser<TOption>, TOption, OptionParser<TOption>>()
      .AddParser<IEnumParser<TOption>, TOption, EnumParser<TOption>>();

  public static IServiceCollection AddObjectParser<TObject, TField, TRef>(this IServiceCollection services)
    where TObject : ParseObjectDefinition<TField, TRef>
    where TField : AstObjectField<TRef>
    where TRef : AstReference<TRef>
    => services.AddParser<ObjectDefinition<TField, TRef>, TObject>();

  public static IServiceCollection AddDeclarationParser<TObject, TParser>(this IServiceCollection services, string selector)
    where TObject : AstDeclaration
    where TParser : class, Parser<TObject>.I
    => services
      .AddParser<TObject, TParser>()
      .AddSingleton<IParseDeclaration>(c => new ParseDeclaration<TObject>(selector, c.GetRequiredService<Parser<TObject>.D>()));

  public static IServiceCollection AddDomainParser<TDomain, TParser>(this IServiceCollection services)
    where TParser : class, Parser<TDomain>.I, IParseDomain
    => services
      .AddArrayParser<TDomain, TParser>()
      .AddSingleton<IParseDomain>(c => c.GetRequiredService<TParser>());

  public static IServiceCollection AddNullParsers(this IServiceCollection services)
    => services
      .AddParser<NullAst, ParseNull>()
      .AddParserArray<NullAst, ParseNulls>()
      .AddParser<IOptionParser<NullOption>, NullOption, ParseNullOption>()
      .AddParser<IEnumParser<NullOption>, NullOption, ParseNullOption>();
}
