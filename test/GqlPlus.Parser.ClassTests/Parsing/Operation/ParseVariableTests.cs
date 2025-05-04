﻿using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariableTests
  : ParserClassTestBase
{
  private readonly ParseVariable _parseVariable;
  private readonly Parser<IGqlpModifier>.IA _modifiersParser;
  private readonly Parser<IGqlpDirective>.IA _directivesParser;
  private readonly Parser<IGqlpConstant>.I _defaultParser;
  private readonly Parser<string>.I _varTypeParser;

  public ParseVariableTests()
  {
    Parser<IGqlpModifier>.DA modifiers = ParserAFor(out _modifiersParser);
    Parser<IGqlpDirective>.DA directives = ParserAFor(out _directivesParser);
    Parser<IParserDefault, IGqlpConstant>.D defaultParser = ParserFor<IParserDefault, IGqlpConstant>(out _defaultParser);
    Parser<IParserVarType, string>.D varTypeParser = ParserFor<IParserVarType, string>(out _varTypeParser);

    _parseVariable = new ParseVariable(modifiers, directives, defaultParser, varTypeParser);

    SetupError<IGqlpVariable>();
    SetupPartial<IGqlpVariable>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableAndType_WhenValidVariableWithTypeIsParsed(string variableName, string varType)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    TakeReturns(':', true);
    ParseOk(_varTypeParser, varType);

    IGqlpModifier[] modifiers = ParseOkA(_modifiersParser);
    IGqlpConstant constant = ParseOk(_defaultParser);

    IGqlpDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpVariable>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Identifier.ShouldBe(variableName),
        x => x.Type.ShouldBe(varType),
        x => x.Modifiers.ShouldBe(modifiers),
        x => x.DefaultValue.ShouldBe(constant),
        x => x.Directives.ShouldBe(directives)
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariable_WhenValidVariableIsParsed(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));

    IGqlpModifier[] modifiers = ParseOkA(_modifiersParser);
    IGqlpConstant constant = ParseOk(_defaultParser);

    IGqlpDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpVariable>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Identifier.ShouldBe(variableName),
        x => x.Type.ShouldBeNull(),
        x => x.Modifiers.ShouldBe(modifiers),
        x => x.DefaultValue.ShouldBe(constant),
        x => x.Directives.ShouldBe(directives)
      );
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenVariableNameIsMissing()
  {
    // Arrange
    PrefixReturns('$', OutFail);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenTypeIsMissingAfterColon(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    TakeReturns(':', true);
    ParseEmpty(_varTypeParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenModifiersParsingFails(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    ParseErrorA(_modifiersParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultParsingFails(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));

    ParseEmptyA(_modifiersParser);
    ParseError(_defaultParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpVariable>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokensAreParsed()
  {
    // Arrange
    PrefixReturns('$', OutPass);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty<IGqlpVariable>>();
  }
}
