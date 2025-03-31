using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Parsing.Schema.Globals;
using GqlPlus.Parsing.Schema.Objects;
using GqlPlus.Parsing.Schema.Simple;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Schema;

public static class SchemaParsers
{
  public static IServiceCollection AddSchemaParsers(this IServiceCollection services)
    => services
      .AddNullParsers()
      .AddParserArray<string, ParseAliases>()
      // Category
      .AddSingleton<ICategoryName, CategoryName>()
      .AddOption<CategoryOption>()
      .AddParser<CategoryOutput, ParseCategoryDefinition>()
      .AddDeclarationParser<IGqlpSchemaCategory, ParseCategory>("category")
      // Directive
      .AddSingleton<IDirectiveName, DirectiveName>()
      .AddOption<DirectiveOption>()
      .AddEnum<DirectiveLocation>()
      .AddParser<DirectiveLocation, ParseDirectiveDefinition>()
      .AddDeclarationParser<IGqlpSchemaDirective, ParseDirective>("directive")
      // Option
      .AddParser<OptionDefinition, ParseOptionDefinition>()
      .AddParser<IGqlpSchemaSetting, ParseOptionSetting>()
      .AddDeclarationParser<IGqlpSchemaOption, ParseOption>("option")
      // Types
      .AddParser<IGqlpTypeRef, ParseTypeRef>()
      .AddSingleton<ISimpleName, SimpleName>()
      // Enum
      .AddParser<EnumDefinition, ParseEnumDefinition>()
      .AddParser<IGqlpEnumLabel, ParseEnumLabel>()
      .AddDeclarationParser<IGqlpEnum, ParseEnum>("enum")
      // Domain
      .AddParser<DomainDefinition, ParseDomainDefinition>()
      .AddEnum<DomainKind>()
      .AddDomainParser<IGqlpDomainTrueFalse, ParseDomainTrueFalse>()
      .AddDomainParser<IGqlpDomainLabel, ParseDomainLabel>()
      .AddDomainParser<IGqlpDomainRange, ParseDomainRange>()
      .AddDomainParser<IGqlpDomainRegex, ParseDomainRegex>()
      .AddDeclarationParser<IGqlpDomain, ParseDomain>("domain")
      // Union
      .AddParser<UnionDefinition, ParseUnionDefinition>()
      .AddParser<IGqlpUnionMember, ParseUnionMember>()
      .AddDeclarationParser<IGqlpUnion, ParseUnion>("union")
      // Objects
      .AddParserArray<IGqlpTypeParam, ParseTypeParams>()
      // Dual
      .AddParserArray<IGqlpDualArg, ParseDualArgs>()
      .AddParser<IGqlpDualBase, ParseDualBase>()
      .AddParser<IGqlpDualField, ParseDualField>()
      .AddParserArray<IGqlpDualAlternate, ParseDualAlternates>()
      .AddDeclarationParser<IGqlpDualObject, ParseDual>("dual")
      .AddObjectParser<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>()
      // Input
      .AddParserArray<IGqlpInputArg, ParseInputArgs>()
      .AddParser<IGqlpInputBase, ParseInputBase>()
      .AddParser<IGqlpInputField, ParseInputField>()
      .AddParserArray<IGqlpInputAlternate, ParseInputAlternates>()
      .AddDeclarationParser<IGqlpInputObject, ParseInput>("input")
      .AddObjectParser<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>()
      .AddParserArray<IGqlpInputParam, ParseInputParams>()
      // Output
      .AddParserArray<IGqlpOutputArg, ParseOutputArgs>()
      .AddParser<IGqlpOutputBase, ParseOutputBase>()
      .AddParser<IGqlpOutputField, ParseOutputField>()
      .AddParserArray<IGqlpOutputAlternate, ParseOutputAlternates>()
      .AddDeclarationParser<IGqlpOutputObject, ParseOutput>("output")
      .AddObjectParser<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>()
      // Schema
      .AddParser<IGqlpSchema, ParseSchema>()
      ;

  private static IServiceCollection AddEnum<TEnum>(this IServiceCollection services)
    where TEnum : struct
    => services.AddParser<IEnumParser<TEnum>, TEnum, EnumParser<TEnum>>();

  private static IServiceCollection AddOption<TOption>(this IServiceCollection services)
    where TOption : struct
    => services
      .AddParser<IOptionParser<TOption>, TOption, OptionParser<TOption>>()
      .AddParser<IEnumParser<TOption>, TOption, EnumParser<TOption>>();

  private static IServiceCollection AddObjectParser<TObjBase, TObjField, TObjAlt>(this IServiceCollection services)
    where TObjBase : IGqlpObjBase
    where TObjField : IGqlpObjField
    where TObjAlt : IGqlpObjAlternate
    => services
      .AddParser<ObjectDefinition<TObjBase, TObjField, TObjAlt>, ParseObjectDefinition<TObjBase, TObjField, TObjAlt>>();

  private static IServiceCollection AddDeclarationParser<TObject, TParser>(this IServiceCollection services, string selector)
    where TObject : IGqlpDeclaration
    where TParser : class, Parser<TObject>.I
    => services
      .AddParser<TObject, TParser>()
      .AddSingleton<IDeclarationSelector<TObject>>(new DeclarationSelector<TObject>(selector))
      .AddSingleton<IParseDeclaration, ParseDeclaration<TObject>>();

  private static IServiceCollection AddDomainParser<TDomain, TParser>(this IServiceCollection services)
    where TParser : class, Parser<TDomain>.I, IParseDomain
    => services
      .AddArrayParser<TDomain, TParser>()
      .AddProvider<TParser, IParseDomain>();

  private static IServiceCollection AddNullParsers(this IServiceCollection services)
    => services
      .AddParserArray<NullAst, ParseNulls>()
      .AddParser<IOptionParser<NullOption>, NullOption, ParseNullOption>()
      .AddParser<IEnumParser<NullOption>, NullOption, ParseNullOption>();
}
