using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseSelectionTests
  : ModifiersClassTestBase
{

  private readonly ParseSelection _parseSelection;
  private readonly IParserArray<IAstDirective> _directivesParser;
  private readonly IParserArray<IAstSelection> _objectParser;

  public ParseSelectionTests()
    : base(A.Of<ITokenizer, IOperationContext>())
  {
    ConfigureRepoArray(Parsers, out _directivesParser);
    ConfigureRepoArray(Parsers, out _objectParser);
    _parseSelection = new ParseSelection(Parsers);

    SetupError<IAstSelection>();
  }

  [Theory, RepeatData]
  public void ParseSpread_ShouldReturnSelection_WhenSpreadIsParsed(string spreadName)
  {
    // Arrange
    TakeReturns("...", true);
    IdentifierReturns(OutString(spreadName));

    IAstModifier[] modifiers = ParseAModifier();
    IAstDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSelection>>()
      .Required().ShouldBeAssignableTo<IAstSpread>()
      .ShouldSatisfyAllConditions(
        x => x.Identifier.ShouldBe(spreadName),
        x => x.Modifiers.ShouldBe(modifiers),
        x => x.Directives.ShouldBe(directives)
      );
  }

  [Theory, RepeatData]
  public void ParseSpread_ShouldReturnError_WhenModifiersParsingFails(string spreadName)
  {
    // Arrange
    TakeReturns("...", true);
    IdentifierReturns(OutString(spreadName));
    ParseModifiersError();

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void ParseSpread_ShouldReturnError_WhenDirectivesParsingFails(string spreadName)
  {
    // Arrange
    TakeReturns("...", true);
    IdentifierReturns(OutString(spreadName));
    ParseErrorA(_directivesParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void ParseInline_ShouldReturnSelection_WhenInlineFragmentIsParsed(string onType)
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    IdentifierReturns(OutString(onType));

    IAstModifier[] modifiers = ParseAModifier();
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSelection>>()
      .Required().ShouldBeAssignableTo<IAstInline>()
      .ShouldSatisfyAllConditions(
        x => x.OnType.ShouldBe(onType),
        x => x.Modifiers.ShouldBe(modifiers),
        x => x.Directives.ShouldBe(directives),
        x => x.Selections.ShouldBe(selections)
      );
  }

  [Fact]
  public void ParseInline_ShouldReturnSelection_WhenInlineWithModifiersIsParsed()
  {
    // Arrange
    TakeReturns("...", false);
    TakeReturns('|', true);
    TakeReturns("on", false);
    TakeReturns(':', false);
    IdentifierReturns(OutFail);

    IAstModifier[] modifiers = ParseAModifier();
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSelection>>()
      .Required().ShouldBeAssignableTo<IAstInline>()
      .ShouldSatisfyAllConditions(
        x => x.OnType.ShouldBeNull(),
        x => x.Modifiers.ShouldBe(modifiers),
        x => x.Directives.ShouldBe(directives),
        x => x.Selections.ShouldBe(selections)
      );
  }

  [Fact]
  public void ParseInline_ShouldReturnError_WhenTypeIsMissingAfterOn()
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    Tokenizer.Identifier(out string? type).Returns(false);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void ParseInline_ShouldReturnError_WhenModifiersParsingFails(string testType)
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    IdentifierReturns(OutString(testType));
    ParseModifiersError();
    IAstSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void ParseInline_ShouldReturnError_WhenDirectivesParsingFails(string testType)
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    IdentifierReturns(OutString(testType));
    ParseErrorA(_directivesParser);
    IAstSelection[] selections = ParseOkA(_objectParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void ParseInline_ShouldReturnError_WhenObjectParsingFails(string testType)
  {
    // Arrange
    TakeReturns("...", true);
    TakeReturns("on", true);
    IdentifierReturns(OutString(testType));
    ParseErrorA(_objectParser);

    // Act
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

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
    IResult<IAstSelection> result = _parseSelection.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
