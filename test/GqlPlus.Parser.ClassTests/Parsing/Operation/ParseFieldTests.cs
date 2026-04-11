using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseFieldTests
  : ModifiersClassTestBase
{

  private readonly ParseField _parseField;
  private readonly Parser<IAstDirective>.IA _directivesParser;
  private readonly IParserArg _argumentParser;
  private readonly Parser<IAstSelection>.IA _objectParser;

  public ParseFieldTests()
  {
    ConfigureRepoArray<IAstDirective>(Parsers, out _directivesParser);
    ConfigureRepoInterface<IParserArg, IAstArg>(Parsers, out _argumentParser);
    ConfigureRepoArray<IAstSelection>(Parsers, out _objectParser);
    _parseField = new ParseField(Parsers);

    SetupError<IAstField>();
    SetupPartial<IAstField>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnField_WhenAliasAndNameAreParsed(string name, string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias), OutString(name));
    TakeReturns(':', true);

    IAstArg argument = ParseOk(_argumentParser);
    IAstModifier[] modifiers = ParseAModifier();
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IAstField> result = _parseField.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstField>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.FieldAlias.ShouldBe(alias),
        x => x.Identifier.ShouldBe(name),
        x => x.Arg.ShouldBe(argument),
        x => x.Modifiers.ShouldBe(modifiers),
        x => x.Directives.ShouldBe(directives),
        x => x.Selections.ShouldBe(selections)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenAliasIsMissing()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IAstField> result = _parseField.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenNameIsMissingAfterAlias(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    TakeReturns(':', true);

    // Act
    IResult<IAstField> result = _parseField.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenModifiersParsingFails(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    ParseModifiersError();

    // Act
    IResult<IAstField> result = _parseField.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenSelectionsParsingFails(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    ParseErrorA(_objectParser);

    // Act
    IResult<IAstField> result = _parseField.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenDirectivesParsingFails(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    ParseErrorA(_directivesParser);

    // Act
    IResult<IAstField> result = _parseField.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstField>>();
  }
}
