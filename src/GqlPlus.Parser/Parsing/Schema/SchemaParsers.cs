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
      // Operation
      .AddParser<OperationDefinition, ParseOperationDefinition>()
      .AddDeclarationParser<IGqlpSchemaOperation, ParseOperationDecl>("operation")
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
      .AddParserArray<IGqlpAlternate, ParseAlternates>()
      .AddParser<IGqlpObjBase, ParseObjBase>()
      .AddParserArray<IGqlpTypeArg, ParseTypeArgs>()
      .AddObjectParser<IGqlpDualField, ParseDualField>(TypeKind.Dual)
      .AddObjectParser<IGqlpInputField, ParseInputField>(TypeKind.Input)
      .AddParserArray<IGqlpInputParam, ParseInputParams>()
      .AddObjectParser<IGqlpOutputField, ParseOutputField>(TypeKind.Output)
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

  [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase")]
  private static IServiceCollection AddObjectParser<TObjField, TParser>(this IServiceCollection services, TypeKind kind)
    where TObjField : IGqlpObjField
    where TParser : class, Parser<TObjField>.I
    => services
      .AddParser<TObjField, TParser>()
      .AddDeclarationParser<IGqlpObject<TObjField>, ObjectParser<TObjField>>(kind.ToString().ToLowerInvariant())
      .AddParser<ObjectDefinition<TObjField>, ParseObjectDefinition<TObjField>>();

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
