using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseOperationTests
  : ModifiersClassTestBase
{
  private readonly ParseOperation _parseOperation;
  private readonly Parser<IGqlpArg>.I _argumentParser;
  private readonly Parser<IGqlpDirective>.IA _directivesParser;
  private readonly Parser<IGqlpFragment>.IA _startFragmentsParser;
  private readonly Parser<IGqlpFragment>.IA _endFragmentsParser;
  private readonly Parser<IGqlpSelection>.IA _objectParser;
  private readonly Parser<IGqlpVariable>.IA _variablesParser;

  public ParseOperationTests()
    : base(For<IOperationContext>())
  {
    if (Tokenizer is IOperationContext operation) {
      operation.Variables.Returns([]);
      operation.Spreads.Returns([]);
    }

    Parser<IParserArg, IGqlpArg>.D argument = ParserFor<IParserArg, IGqlpArg>(out _argumentParser);
    Parser<IGqlpDirective>.DA directives = ParserAFor(out _directivesParser);
    ParserArray<IParserStartFragments, IGqlpFragment>.DA startFragments = ParserAFor<IParserStartFragments, IGqlpFragment>(out _startFragmentsParser);
    ParserArray<IParserEndFragments, IGqlpFragment>.DA endFragments = ParserAFor<IParserEndFragments, IGqlpFragment>(out _endFragmentsParser);
    Parser<IGqlpSelection>.DA objectParser = ParserAFor(out _objectParser);
    Parser<IGqlpVariable>.DA variables = ParserAFor(out _variablesParser);

    _parseOperation = new ParseOperation(argument, directives, startFragments, endFragments, Modifiers, objectParser, variables);

    SetupError<IGqlpOperation>();
    SetupPartial<IGqlpOperation>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOperation_WhenAllComponentsAreParsed(string resultType)
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    Tokenizer.AtEnd.Returns(true);

    IGqlpVariable[] variables = ParseOkA(_variablesParser);
    IGqlpDirective[] directives = ParseOkA(_directivesParser);
    IGqlpFragment[] startFragments = ParseOkA(_startFragmentsParser);

    PrefixReturns(':', OutStringAt(resultType));

    IGqlpArg argument = ParseOk(_argumentParser);
    IGqlpModifier[] modifiers = ParseAModifier();
    IGqlpFragment[] endFragments = ParseOkA(_endFragmentsParser);

    // Act
    IResult<IGqlpOperation> result = _parseOperation.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOperation>>()
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
  public void Parse_ShouldReturnError_WhenVariablesParsingFails()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    ParseErrorA(_variablesParser);

    // Act
    IResult<IGqlpOperation> result = _parseOperation.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenResultTypeIsMissing()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    IGqlpVariable[] variables = ParseOkA(_variablesParser);
    PrefixReturns(':', OutFail);

    // Act
    IResult<IGqlpOperation> result = _parseOperation.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenObjectParsingFails()
  {
    // Arrange
    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
    IGqlpVariable[] variables = ParseOkA(_variablesParser);
    PrefixReturns(':', OutPass);
    ParseErrorA(_objectParser);

    // Act
    IResult<IGqlpOperation> result = _parseOperation.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartialResult_WhenNoValidTokensAreParsed()
  {
    // Arrange
    Tokenizer.AtStart.Returns(false);
    Tokenizer.Read().Returns(false);
    PrefixReturns(':', OutPass);

    // Act
    IResult<IGqlpOperation> result = _parseOperation.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpOperation>>();
  }
}
