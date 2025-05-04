using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariablesTests
  : ParserClassTestBase
{
  private readonly ParseVariables _parseVariables;
  private readonly Parser<IGqlpVariable>.I _variableParser;

  public ParseVariablesTests()
  {
    Parser<IGqlpVariable>.D variable = ParserFor(out _variableParser);
    _parseVariables = new ParseVariables(variable);
  }

  [Fact]
  public void Parse_ShouldReturnVariablesArray_WhenVariablesAreParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', true);

    IGqlpVariable variable = EFor<IGqlpVariable>();
    Parse(_variableParser, variable.Ok(), variable.Empty());

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpVariable>>()
      .Required().ShouldContain(variable);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenVariableParsingFails()
  {
    // Arrange
    TakeReturns('(', true);
    ParseError(_variableParser);
    SetupError<IGqlpVariable>();

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpVariable>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenClosingParenthesisIsMissing()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);
    IGqlpVariable variable = EFor<IGqlpVariable>();
    Parse(_variableParser, variable.Ok(), variable.Empty());
    SetupPartial<IGqlpVariable>(variable);

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpVariable>>()
      .Result.ShouldContain(variable);
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenOpeningParenthesisIsMissing()
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IGqlpVariable>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoVariablesAreParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);
    ParseEmpty(_variableParser);
    SetupError<IGqlpVariable>();

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpVariable>>();
  }
}
