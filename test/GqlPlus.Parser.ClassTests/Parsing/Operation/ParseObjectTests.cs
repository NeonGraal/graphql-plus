using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseObjectTests
  : ParserClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly ParseObject _parseObject;
  private readonly Parser<IGqlpField>.I _fieldParser;
  private readonly Parser<IGqlpSelection>.I _selectionParser;

  public ParseObjectTests()
  {
    Parser<IGqlpField>.D field = ParserFor(out _fieldParser);
    Parser<IGqlpSelection>.D selection = ParserFor(out _selectionParser);

    _parseObject = new ParseObject(field, selection);

    SetupPartial<IGqlpSelection>();
  }

  [Fact]
  public void Parse_ShouldReturnSelectionsArray_WhenFieldsĀndSelectionsAreParsed()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', false, false, true);

    IGqlpSelection selection = A.Error<IGqlpSelection>();
    ParseOk(_selectionParser, selection);
    IGqlpField field = ParseOk(_fieldParser);

    // Act
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpSelection>>()
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

    IGqlpField field = ParseOk(_fieldParser);

    // Act
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpSelection>>()
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

    IGqlpSelection selection = ParseOk(_selectionParser);

    // Act
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpSelection>>()
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
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpSelection>>();
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
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpSelection>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenNoFieldsOrSelectionsAreParsed()
  {
    // Arrange
    TakeReturns('{', true);
    TakeReturns('}', true);

    // Act
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpSelection>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenOpeningBraceIsMissing()
  {
    // Arrange
    Tokenizer.Take('{').Returns(false);

    // Act
    IResultArray<IGqlpSelection> result = _parseObject.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IGqlpSelection>>();
  }
}
