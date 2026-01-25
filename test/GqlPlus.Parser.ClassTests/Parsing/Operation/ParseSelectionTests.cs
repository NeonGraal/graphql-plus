using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseSelectionTests
  : ParserClassTestBase
{

  private readonly ParseSelection _parseSelection;
  private readonly Parser<IGqlpDirective>.IA _directivesParser;
  private readonly Parser<IGqlpSelection>.IA _objectParser;

  public ParseSelectionTests()
    : base(A.Of<ITokenizer, IOperationContext>())
  {
    Parser<IGqlpDirective>.DA directives = ParserAFor(out _directivesParser);
    Parser<IGqlpSelection>.DA objectParser = ParserAFor(out _objectParser);

    _parseSelection = new ParseSelection(directives, objectParser);

    SetupError<IGqlpSelection>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnSpreadSelection_WhenSpreadIsParsed(string spreadName)
  {
    // Arrange
    TakeReturns("...", true);
    IdentifierReturns(OutString(spreadName));

    IGqlpDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IGqlpSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSelection>>()
      .Required().ShouldBeAssignableTo<IGqlpSpread>()
      .ShouldSatisfyAllConditions(
        x => x.Identifier.ShouldBe(spreadName),
        x => x.Directives.ShouldBe(directives)
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInlineSelection_WhenInlineFragmentIsParsed(string onType)
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    IdentifierReturns(OutString(onType));

    IGqlpDirective[] directives = ParseOkA(_directivesParser);
    IGqlpSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IGqlpSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSelection>>()
      .Required().ShouldBeAssignableTo<IGqlpInline>()
      .ShouldSatisfyAllConditions(
        x => x.OnType.ShouldBe(onType),
        x => x.Directives.ShouldBe(directives),
        x => x.Selections.ShouldBe(selections)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenTypeIsMissingAfterOn()
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    Tokenizer.Identifier(out string? type).Returns(false);

    // Act
    IResult<IGqlpSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenObjectParsingFails(string testType)
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    IdentifierReturns(OutString(testType));
    ParseErrorA(_objectParser);

    // Act
    IResult<IGqlpSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokensAreParsed()
  {
    // Arrange
    TakeReturns("...", false);
    TakeReturns('|', false);

    // Act
    IResult<IGqlpSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
