using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariablesTests
  : ParserClassTestBase
{

  private readonly ParseVariables _parseVariables;
  private readonly Parser<IAstVariable>.I _variableParser;

  public ParseVariablesTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstVariable>(parsers, out _variableParser);
    _parseVariables = new ParseVariables(parsers);

    SetupError<IAstVariable>();
    SetupPartial<IAstVariable>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariablesArray_WhenVariablesAreParsed(string name)
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', true);

    IAstVariable variable = A.Variable(name);
    variable.Equals(Arg.Any<IAstVariable>()).Returns(c => c[0] == variable);
    ParseOk(_variableParser, variable);

    // Act
    IResultArray<IAstVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstVariable>>()
      .Required().ShouldContain(variable);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenVariableParsingFails()
  {
    // Arrange
    TakeReturns('(', true);
    ParseError(_variableParser);

    // Act
    IResultArray<IAstVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenClosingParenthesisIsMissing(string name)
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);
    IAstVariable variable = A.Variable(name);
    Parse(_variableParser, variable.Ok(), variable.Empty());

    // Act
    IResultArray<IAstVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstVariable>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenOpeningParenthesisIsMissing()
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResultArray<IAstVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IAstVariable>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoVariablesAreParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);
    ParseEmpty(_variableParser);

    // Act
    IResultArray<IAstVariable> result = _parseVariables.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IAstVariable>>();
  }
}
