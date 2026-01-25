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

    SetupError<IGqlpVariable>();
    SetupPartial<IGqlpVariable>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariablesArray_WhenVariablesAreParsed(string name)
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', true);

    IGqlpVariable variable = A.Variable(name);
    variable.Equals(Arg.Any<IGqlpVariable>()).Returns(c => c[0] == variable);
    ParseOk(_variableParser, variable);

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

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

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenClosingParenthesisIsMissing(string name)
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);
    IGqlpVariable variable = A.Variable(name);
    Parse(_variableParser, variable.Ok(), variable.Empty());

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpVariable>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenOpeningParenthesisIsMissing()
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

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

    // Act
    IResultArray<IGqlpVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpVariable>>();
  }
}
