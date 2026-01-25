using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariableTests
  : ModifiersClassTestBase
{
  private readonly ParseVariable _parseVariable;
  private readonly Parser<IGqlpDirective>.IA _directivesParser;
  private readonly IParserDefault _defaultParser;
  private readonly IParserVarType _varTypeParser;

  public ParseVariableTests()
  {
    Parser<IGqlpDirective>.DA directives = ParserAFor(out _directivesParser);
    Parser<IParserDefault, IGqlpConstant>.D defaultParser = ParserFor<IParserDefault, IGqlpConstant>(out _defaultParser);
    Parser<IParserVarType, string>.D varTypeParser = ParserFor<IParserVarType, string>(out _varTypeParser);

    _parseVariable = new ParseVariable(Modifiers, directives, defaultParser, varTypeParser);

    SetupError<IGqlpVariable>();
    SetupPartial<IGqlpVariable>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableAndType_WhenValidVariableWithTypeIsParsed(string variableName, string varType, string label)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    TakeReturns(':', true);
    ParseOk(_varTypeParser, varType);

    IGqlpModifier[] modifiers = ParseAModifier();
    IGqlpConstant constant = ParseOk(_defaultParser);

    IGqlpDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

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
  public void Parse_ShouldReturnVariable_WhenValidVariableIsParsed(string variableName, string label)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));

    IGqlpModifier[] modifiers = ParseAModifier();
    IGqlpConstant constant = ParseOk(_defaultParser);

    IGqlpDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

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

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenVariableNameIsMissing(string label)
  {
    // Arrange
    PrefixReturns('$', OutFail);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenTypeIsMissingAfterColon(string variableName, string label)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    TakeReturns(':', true);
    ParseEmpty(_varTypeParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenModifiersParsingFails(string variableName, string label)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    ParseModifiersError();

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultParsingFails(string variableName, string label)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));

    ParseModifiersEmpty();
    ParseError(_defaultParser);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokensAreParsed(string label)
  {
    // Arrange
    PrefixReturns('$', OutPass);

    // Act
    IResult<IGqlpVariable> result = _parseVariable.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
