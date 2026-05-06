using GqlPlus.Ast.Schema;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Globals;
using GqlPlus.Parsing.Schema.Objects;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

public static class SchemaParsers
{
  public static IParserRepositoryBuilder AddSchemaParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddNullParsers()
      .AddArray(ParseAliases.Factory)
      .AddSingle(ParseTypeRef.Factory)
      .AddInterfaceSingle<ISimpleName>(SimpleName.Factory)
      .AddSchemaCategoryParsers()
      .AddSchemaDirectiveParsers()
      .AddSchemaOptionParsers()
      .AddSchemaSimpleParsers()
      .AddSchemaObjectParsers()
      .AddSingle(ParseSchema.Factory);

  public static IParserRepositoryBuilder AddSchemaCategoryParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddInterfaceSingle<ICategoryName>(CategoryName.Factory)
      .AddOption<CategoryOption>()
      .AddSingle(ParseCategoryDefinition.Factory)
      .AddDeclarationParser("category", ParseCategory.Factory);

  public static IParserRepositoryBuilder AddSchemaDirectiveParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddInterfaceSingle<IDirectiveName>(DirectiveName.Factory)
      .AddOption<DirectiveOption>()
      .AddEnum<DirectiveLocation>()
      .AddSingle(ParseDirectiveDefinition.Factory)
      .AddDeclarationParser("directive", ParseDirective.Factory);

  public static IParserRepositoryBuilder AddSchemaOptionParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddSingle(ParseOptionDefinition.Factory)
      .AddSingle(ParseOptionSetting.Factory)
      .AddDeclarationParser("option", ParseOption.Factory);

  public static IParserRepositoryBuilder AddSchemaSimpleParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddSchemaDomainParsers()
      // Enum
      .AddSingle(ParseEnumDefinition.Factory)
      .AddSingle(ParseEnumLabel.Factory)
      .AddDeclarationParser("enum", ParseEnum.Factory)
      // Union
      .AddSingle(ParseUnionDefinition.Factory)
      .AddSingle(ParseUnionMember.Factory)
      .AddDeclarationParser("union", ParseUnion.Factory);

  public static IParserRepositoryBuilder AddSchemaDomainParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddSingle(ParseDomainDefinition.Factory)
      .AddEnum<DomainKind>()
      .AddDomainParser(ParseDomainTrueFalse.Factory)
      .AddDomainParser(ParseDomainLabel.Factory)
      .AddDomainParser(ParseDomainRange.Factory)
      .AddDomainParser(ParseDomainRegex.Factory)
      .AddDeclarationParser("domain", ParseDomain.Factory);

  public static IParserRepositoryBuilder AddSchemaObjectParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddArray(ParseTypeParams.Factory)
      .AddArray(ParseAlternates.Factory)
      .AddSingle(ParseObjBase.Factory)
      .AddArray(ParseTypeArgs.Factory)
      .AddArray(ParseInputParams.Factory)
      .AddSchemaObjectTypeParsers();

  public static IParserRepositoryBuilder AddSchemaObjectTypeParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddObjectParser(TypeKind.Dual, ParseDualField.Factory)
      .AddObjectParser(TypeKind.Input, ParseInputField.Factory)
      .AddObjectParser(TypeKind.Output, ParseOutputField.Factory);

  private static IParserRepositoryBuilder AddEnum<TEnum>(this IParserRepositoryBuilder builder)
    where TEnum : struct
    => builder.AddInterfaceSingle<IEnumParser<TEnum>>(EnumParser<TEnum>.Factory);

  private static IParserRepositoryBuilder AddOption<TOption>(this IParserRepositoryBuilder builder)
    where TOption : struct
    => builder
      .AddInterfaceSingle<IOptionParser<TOption>>(OptionParser<TOption>.Factory)
      .AddEnum<TOption>();

  [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase")]
  private static IParserRepositoryBuilder AddObjectParser<TObjField>(this IParserRepositoryBuilder builder, TypeKind fieldKind, Factory<Parser<TObjField>.I, IParserRepository> factory)
    where TObjField : IAstObjField
    => builder
      .AddSingle(factory)
      .AddSingle(ParseObjectDefinition<TObjField>.Factory)
      .AddDeclarationParser(fieldKind.ToString().ToLowerInvariant(), ObjectParser<TObjField>.Factory(fieldKind));

  private static IParserRepositoryBuilder AddDeclarationParser<TObject>(this IParserRepositoryBuilder builder, string selector, Factory<Parser<TObject>.I, IParserRepository> factory)
    where TObject : IAstDeclaration
    => builder
      .AddSingle(factory)
      .AddDeclaration<TObject>(ParseDeclaration<TObject>.Factory(selector));

  private static IParserRepositoryBuilder AddDomainParser<TDomain>(this IParserRepositoryBuilder builder, Factory<Parser<TDomain>.I, IParserRepository> factory)
    => builder
      .AddSingle(factory)
      .AddArray(ArrayParser<TDomain>.Factory)
      .AddDomain<TDomain>();

  private static IParserRepositoryBuilder AddNullParsers(this IParserRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddArray(ParseNulls.Factory)
      .AddInterfaceSingle<IOptionParser<NullOption>>(ParseNullOption.Factory)
      .AddInterfaceSingle<IEnumParser<NullOption>>(ParseNullOption.Factory);
}
