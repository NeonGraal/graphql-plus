using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseFieldTests
  : ParserClassTestBase
{
  private readonly ParseField _parseField;
  private readonly Parser<IGqlpModifier>.IA _modifiersParser;
  private readonly Parser<IGqlpDirective>.IA _directivesParser;
  private readonly Parser<IGqlpArg>.I _argumentParser;
  private readonly Parser<IGqlpSelection>.IA _objectParser;

  public ParseFieldTests()
  {
    Parser<IGqlpModifier>.DA modifiers = ParserAFor(out _modifiersParser);
    Parser<IGqlpDirective>.DA directives = ParserAFor(out _directivesParser);
    Parser<IParserArg, IGqlpArg>.D argument = ParserFor<IParserArg, IGqlpArg>(out _argumentParser);
    Parser<IGqlpSelection>.DA objectParser = ParserAFor(out _objectParser);

    _parseField = new ParseField(modifiers, directives, argument, objectParser);

    SetupError<IGqlpField>();
    SetupPartial<IGqlpField>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnField_WhenAliasAndNameAreParsed(string name, string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias), OutString(name));
    TakeReturns(':', true);

    IGqlpArg argument = ParseOk(_argumentParser);
    IGqlpModifier[] modifiers = ParseOkA(_modifiersParser);
    IGqlpDirective[] directives = ParseOkA(_directivesParser);
    IGqlpSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IGqlpField> result = _parseField.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpField>>()
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
    IResult<IGqlpField> result = _parseField.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenNameIsMissingAfterAlias(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias), OutFail);
    TakeReturns(':', true);

    // Act
    IResult<IGqlpField> result = _parseField.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenModifiersParsingFails(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    ParseErrorA(_modifiersParser);

    // Act
    IResult<IGqlpField> result = _parseField.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenSelectionsParsingFails(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    ParseErrorA(_objectParser);

    // Act
    IResult<IGqlpField> result = _parseField.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenDirectivesParsingFails(string alias)
  {
    // Arrange
    IdentifierReturns(OutString(alias));
    ParseErrorA(_directivesParser);

    // Act
    IResult<IGqlpField> result = _parseField.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpField>>();
  }
}
