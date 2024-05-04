using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parse.Schema.Globals;
using GqlPlus.Parse.Schema.Objects;
using GqlPlus.Parse.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parse.Schema;

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
      .AddSingleton<ISimpleName, SimpleName>()
      // Enum
      .AddParser<EnumDefinition, ParseEnumDefinition>()
      .AddParser<EnumMemberAst, ParseEnumMember>()
      .AddDeclarationParser<IGqlpEnum, ParseEnum>("enum")
      // Domain
      .AddParser<DomainDefinition, ParseDomainDefinition>()
      .AddEnum<DomainKind>()
      .AddDomainParser<DomainTrueFalseAst, ParseDomainTrueFalse>()
      .AddDomainParser<DomainMemberAst, ParseDomainMember>()
      .AddDomainParser<DomainRangeAst, ParseDomainRange>()
      .AddDomainParser<DomainRegexAst, ParseDomainRegex>()
      .AddDeclarationParser<IGqlpDomain, ParseDomain>("domain")
      // Union
      .AddParser<UnionDefinition, ParseUnionDefinition>()
      .AddParser<UnionMemberAst, ParseUnionMember>()
      .AddDeclarationParser<IGqlpUnion, ParseUnion>("union")
      // Objects
      .AddParserArray<TypeParameterAst, ParseTypeParameters>()
      // Dual
      .AddParser<DualBaseAst, ParseDualBase>()
      .AddParser<DualFieldAst, ParseDualField>()
      .AddDeclarationParser<DualDeclAst, ParseDual>("dual")
      .AddObjectParser<ParseDualDefinition, DualFieldAst, DualBaseAst>()
      // Input
      .AddParser<InputBaseAst, ParseInputBase>()
      .AddParser<InputFieldAst, ParseInputField>()
      .AddDeclarationParser<InputDeclAst, ParseInput>("input")
      .AddObjectParser<ParseInputDefinition, InputFieldAst, InputBaseAst>()
      // Output
      .AddParser<OutputBaseAst, ParseOutputBase>()
      .AddParser<OutputFieldAst, ParseOutputField>()
      .AddDeclarationParser<OutputDeclAst, ParseOutput>("output")
      .AddObjectParser<ParseOutputDefinition, OutputFieldAst, OutputBaseAst>()
      // Schema
      .AddParser<IGqlpSchema, ParseSchema>()
      ;

  public static IServiceCollection AddEnum<TEnum>(this IServiceCollection services)
    where TEnum : struct
    => services.AddParser<IEnumParser<TEnum>, TEnum, EnumParser<TEnum>>();

  public static IServiceCollection AddOption<TOption>(this IServiceCollection services)
    where TOption : struct
    => services
      .AddParser<IOptionParser<TOption>, TOption, OptionParser<TOption>>()
      .AddParser<IEnumParser<TOption>, TOption, EnumParser<TOption>>();

  public static IServiceCollection AddObjectParser<TObject, TObjField, TObjBase>(this IServiceCollection services)
    where TObject : ParseObjectDefinition<TObjField, TObjBase>
    where TObjField : AstObjectField<TObjBase>
    where TObjBase : AstObjectBase<TObjBase>
    => services.AddParser<ObjectDefinition<TObjField, TObjBase>, TObject>();

  public static IServiceCollection AddDeclarationParser<TObject, TParser>(this IServiceCollection services, string selector)
    where TObject : IGqlpDeclaration
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
