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
      .AddArray(_ => new ParseAliases())
      .AddSingle(_ => new ParseTypeRef())
      .AddInterfaceSingle<ISimpleName>(_ => new SimpleName())
      .AddSchemaCategoryParsers()
      .AddSchemaDirectiveParsers()
      .AddSchemaOptionParsers()
      .AddSchemaSimpleParsers()
      .AddSchemaObjectParsers()
      .AddSingle(p => new ParseSchema(p));

  public static IParserRepositoryBuilder AddSchemaCategoryParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddInterfaceSingle<ICategoryName>(_ => new CategoryName())
      .AddOption<CategoryOption>()
      .AddSingle(p => new ParseCategoryDefinition(p))
      .AddDeclarationParser("category", p => new ParseCategory(p));

  public static IParserRepositoryBuilder AddSchemaDirectiveParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddInterfaceSingle<IDirectiveName>(_ => new DirectiveName())
      .AddOption<DirectiveOption>()
      .AddEnum<DirectiveLocation>()
      .AddSingle(p => new ParseDirectiveDefinition(p))
      .AddDeclarationParser("directive", p => new ParseDirective(p));

  public static IParserRepositoryBuilder AddSchemaOptionParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddSingle(p => new ParseOptionDefinition(p))
      .AddSingle(p => new ParseOptionSetting(p))
      .AddDeclarationParser("option", p => new ParseOption(p));

  public static IParserRepositoryBuilder AddSchemaSimpleParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddSchemaDomainParsers()
      // Enum
      .AddSingle(p => new ParseEnumDefinition(p))
      .AddSingle(p => new ParseEnumLabel(p))
      .AddDeclarationParser("enum", p => new ParseEnum(p))
      // Union
      .AddSingle(p => new ParseUnionDefinition(p))
      .AddSingle(_ => new ParseUnionMember())
      .AddDeclarationParser("union", p => new ParseUnion(p));

  public static IParserRepositoryBuilder AddSchemaDomainParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddSingle(p => new ParseDomainDefinition(p))
      .AddEnum<DomainKind>()
      .AddDomainParser(p => new ParseDomainTrueFalse(p))
      .AddDomainParser(p => new ParseDomainLabel(p))
      .AddDomainParser(p => new ParseDomainRange(p))
      .AddDomainParser(p => new ParseDomainRegex(p))
      .AddDeclarationParser("domain", p => new ParseDomain(p));

  public static IParserRepositoryBuilder AddSchemaObjectParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddArray(_ => new ParseTypeParams())
      .AddArray(p => new ParseAlternates(p))
      .AddSingle(p => new ParseObjBase(p))
      .AddArray(_ => new ParseTypeArgs())
      .AddArray(p => new ParseInputParams(p))
      .AddSchemaObjectTypeParsers();

  public static IParserRepositoryBuilder AddSchemaObjectTypeParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
      .AddObjectParser(TypeKind.Dual, p => new ParseDualField(p))
      .AddObjectParser(TypeKind.Input, p => new ParseInputField(p))
      .AddObjectParser(TypeKind.Output, p => new ParseOutputField(p));

  private static IParserRepositoryBuilder AddEnum<TEnum>(this IParserRepositoryBuilder builder)
    where TEnum : struct
    => builder.AddInterfaceSingle<IEnumParser<TEnum>>(_ => new EnumParser<TEnum>());

  private static IParserRepositoryBuilder AddOption<TOption>(this IParserRepositoryBuilder builder)
    where TOption : struct
    => builder
      .AddInterfaceSingle<IOptionParser<TOption>>(p => new OptionParser<TOption>(p))
      .AddEnum<TOption>();

  [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase")]
  private static IParserRepositoryBuilder AddObjectParser<TObjField>(this IParserRepositoryBuilder builder, TypeKind fieldKind, Factory<Parser<TObjField>.I, IParserRepository> factory)
    where TObjField : IAstObjField
    => builder
      .AddSingle(factory)
      .AddSingle(p => new ParseObjectDefinition<TObjField>(p))
      .AddDeclarationParser(fieldKind.ToString().ToLowerInvariant(), p => new ObjectParser<TObjField>(fieldKind, p));

  private static IParserRepositoryBuilder AddDeclarationParser<TObject>(this IParserRepositoryBuilder builder, string selector, Factory<Parser<TObject>.I, IParserRepository> factory)
    where TObject : IAstDeclaration
    => builder
      .AddSingle(factory)
      .AddDeclaration<TObject>(p => new ParseDeclaration<TObject>(selector, p));

  private static IParserRepositoryBuilder AddDomainParser<TDomain>(this IParserRepositoryBuilder builder, Factory<Parser<TDomain>.I, IParserRepository> factory)
    => builder
      .AddSingle(factory)
      .AddArray(p => new ArrayParser<TDomain>(p))
      .AddDomain<TDomain>();

  private static IParserRepositoryBuilder AddNullParsers(this IParserRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddArray(_ => new ParseNulls())
      .AddInterfaceSingle<IOptionParser<NullOption>>(_ => new ParseNullOption())
      .AddInterfaceSingle<IEnumParser<NullOption>>(_ => new ParseNullOption());
}
