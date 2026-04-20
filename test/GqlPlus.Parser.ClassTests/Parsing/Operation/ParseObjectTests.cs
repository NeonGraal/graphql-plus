using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseObjectTests
  : ParserClassTestBase
{

  private readonly ParseObject _parseObject;
  private readonly Parser<IAstField>.I _fieldParser;
  private readonly Parser<IAstSelection>.I _selectionParser;

  public ParseObjectTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstField>(parsers, out _fieldParser);
    ConfigureRepo<IAstSelection>(parsers, out _selectionParser);
    _parseObject = new ParseObject(parsers);

    SetupPartial<IAstSelection>();
  }

  [Fact]
  public void Parse_ShouldReturnSelectionsArray_WhenFieldsĀndSelectionsAreParsed()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', false, false, true);

    IAstSelection selection = A.Error<IAstSelection>();
    ParseOk(_selectionParser, selection);
    IAstField field = ParseOk(_fieldParser);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstSelection>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.ShouldContain(field),
        x => x.ShouldContain(selection)
      );
  }

  [Fact]
  public void Parse_ShouldReturnSelectionsArray_WhenFieldsAreParsed()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', false, true);

    IAstField field = ParseOk(_fieldParser);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstSelection>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.ShouldContain(field)
      );
  }

  [Fact]
  public void Parse_ShouldReturnSelectionsArray_WhenSelectionsAreParsed()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', false, true);

    IAstSelection selection = ParseOk(_selectionParser);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstSelection>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.ShouldContain(selection)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenSelectionParsingFails()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', false);

    ParseError(_selectionParser);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstSelection>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenFieldParsingFails()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', false);

    ParseEmpty(_selectionParser);
    ParseError(_fieldParser);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstSelection>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenNoFieldsOrSelectionsAreParsed()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', true);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstSelection>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenOpeningBraceIsMissing()
  {
    // Arrange
    Tokenizer.Take('{').Returns(false);

    // Act
    IResultArray<IAstSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IAstSelection>>();
  }
}
