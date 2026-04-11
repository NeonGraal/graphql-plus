using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariableTests
  : ModifiersClassTestBase
{

  private readonly ParseVariable _parseVariable;
  private readonly Parser<IAstDirective>.IA _directivesParser;
  private readonly IParserDefault _defaultParser;
  private readonly IParserVarType _varTypeParser;

  public ParseVariableTests()
  {
    ConfigureRepoArray<IAstDirective>(Parsers, out _directivesParser);
    ConfigureRepoInterface<IParserDefault, IAstConstant>(Parsers, out _defaultParser);
    ConfigureRepoInterface<IParserVarType, string>(Parsers, out _varTypeParser);
    _parseVariable = new ParseVariable(Parsers);

    SetupError<IAstVariable>();
    SetupPartial<IAstVariable>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableAndType_WhenValidVariableWithTypeIsParsed(string variableName, string varType)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    TakeReturns(':', true);
    ParseOk(_varTypeParser, varType);

    IAstModifier[] modifiers = ParseAModifier();
    IAstConstant constant = ParseOk(_defaultParser);

    IAstDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstVariable>>()
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

    IAstModifier[] modifiers = ParseAModifier();
    IAstConstant constant = ParseOk(_defaultParser);

    IAstDirective[] directives = ParseOkA(_directivesParser);

    // Act
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstVariable>>()
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
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenTypeIsMissingAfterColon(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    TakeReturns(':', true);
    ParseEmpty(_varTypeParser);

    // Act
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstVariable>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenModifiersParsingFails(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));
    ParseModifiersError();

    // Act
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultParsingFails(string variableName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variableName));

    ParseModifiersEmpty();
    ParseError(_defaultParser);

    // Act
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokensAreParsed()
  {
    // Arrange
    PrefixReturns('$', OutPass);

    // Act
    IResult<IAstVariable> result = _parseVariable.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
