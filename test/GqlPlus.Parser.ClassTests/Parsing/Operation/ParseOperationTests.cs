using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseOperationTests
  : ModifiersClassTestBase
{

  private readonly ParseOperation _parseOperation;
  private readonly IParserArg _argumentParser;
  private readonly Parser<IAstDirective>.IA _directivesParser;
  private readonly IParserStartFragments _startFragmentsParser;
  private readonly IParserEndFragments _endFragmentsParser;
  private readonly Parser<IGqlpSelection>.IA _objectParser;
  private readonly Parser<IAstVariable>.IA _variablesParser;

  public ParseOperationTests()
    : base(A.Of<IOperationContext>())
  {
    if (Tokenizer is IOperationContext operation) {
      operation.Variables.Returns([]);
      operation.Spreads.Returns([]);
    }

    ConfigureRepoInterface<IParserArg, IGqlpArg>(Parsers, out _argumentParser);
    ConfigureRepoArray<IAstDirective>(Parsers, out _directivesParser);
    ConfigureRepoArrayInterface<IParserStartFragments, IAstFragment>(Parsers, out _startFragmentsParser);
    ConfigureRepoArrayInterface<IParserEndFragments, IAstFragment>(Parsers, out _endFragmentsParser);
    ConfigureRepoArray<IGqlpSelection>(Parsers, out _objectParser);
    ConfigureRepoArray<IAstVariable>(Parsers, out _variablesParser);
    _parseOperation = new ParseOperation(Parsers);

    SetupError<IAstOperation>();
    SetupPartial<IAstOperation>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOperation_WhenResultAndOtherComponentsAreParsed(string resultType)
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    Tokenizer.AtEnd.Returns(true);

    IAstVariable[] variables = ParseOkA(_variablesParser);
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstFragment[] startFragments = ParseOkA(_startFragmentsParser);

    PrefixReturns(':', OutStringAt(resultType));

    IGqlpArg argument = ParseOk(_argumentParser);
    IAstModifier[] modifiers = ParseAModifier();
    IAstFragment[] endFragments = ParseOkA(_endFragmentsParser);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstOperation>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Variables.ShouldBe(variables),
        x => x.Directives.ShouldBe(directives),
        // x => x.Fragments.ShouldContain(startFragments.Concat(endFragments)),
        x => x.ResultType.ShouldBe(resultType),
        x => x.Arg.ShouldBe(argument),
        x => x.Modifiers.ShouldBe(modifiers)
      );
  }

  [Fact]
  public void Parse_ShouldReturnOperation_WhenObjectAndOtherComponentsAreParsed()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    Tokenizer.AtEnd.Returns(true);

    IAstVariable[] variables = ParseOkA(_variablesParser);
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstFragment[] startFragments = ParseOkA(_startFragmentsParser);

    PrefixReturns(':', OutStringAt(null));

    IGqlpSelection[] obj = ParseOkA(_objectParser);

    IAstModifier[] modifiers = ParseAModifier();
    IAstFragment[] endFragments = ParseOkA(_endFragmentsParser);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstOperation>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Variables.ShouldBe(variables),
        x => x.Directives.ShouldBe(directives),
        // x => x.Fragments.ShouldContain(startFragments.Concat(endFragments)),
        x => x.ResultObject.ShouldBe(obj),
        x => x.Modifiers.ShouldBe(modifiers)
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenExtraText(string resultType)
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    Tokenizer.AtEnd.Returns(false);

    IAstVariable[] variables = ParseOkA(_variablesParser);
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstFragment[] startFragments = ParseOkA(_startFragmentsParser);

    PrefixReturns(':', OutStringAt(resultType));

    IGqlpArg argument = ParseOk(_argumentParser);
    IAstModifier[] modifiers = ParseAModifier();
    IAstFragment[] endFragments = ParseOkA(_endFragmentsParser);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenModifersErrors(string resultType)
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    Tokenizer.AtEnd.Returns(false);

    IAstVariable[] variables = ParseOkA(_variablesParser);
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstFragment[] startFragments = ParseOkA(_startFragmentsParser);

    PrefixReturns(':', OutStringAt(resultType));

    IGqlpArg argument = ParseOk(_argumentParser);
    ParseModifiersError();

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenArgumentErrors(string resultType)
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    Tokenizer.AtEnd.Returns(false);

    IAstVariable[] variables = ParseOkA(_variablesParser);
    IAstDirective[] directives = ParseOkA(_directivesParser);
    IAstFragment[] startFragments = ParseOkA(_startFragmentsParser);

    PrefixReturns(':', OutStringAt(resultType));

    ParseError(_argumentParser);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoTextToParse()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(false);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenVariablesParsingFails()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    ParseErrorA(_variablesParser);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenResultTypeIsMissing()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    IAstVariable[] variables = ParseOkA(_variablesParser);
    PrefixReturns(':', OutFail);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenObjectParsingFails()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    IAstVariable[] variables = ParseOkA(_variablesParser);
    PrefixReturns(':', OutPass);
    ParseErrorA(_objectParser);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenNoValidTokensAreParsed()
  {
    // Arrange
    Tokenizer.AtStart.Returns(false);
    Tokenizer.Read().Returns(false);
    PrefixReturns(':', OutPass);

    // Act
    IResult<IAstOperation> result = _parseOperation.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstOperation>>();
  }
}
