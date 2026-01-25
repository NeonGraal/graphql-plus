using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseDirectivesTests
  : ParserClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly ParseDirectives _parseDirectives;
  private readonly IParserArg _argumentParser;

  public ParseDirectivesTests()
  {
    Parser<IParserArg, IGqlpArg>.D argumentParser = ParserFor<IParserArg, IGqlpArg>(out _argumentParser);

    _parseDirectives = new ParseDirectives(argumentParser);

    SetupError<IGqlpDirective>();
    SetupPartial<IGqlpDirective>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDirectivesArray_WhenDirectivesAreParsed(string directiveName)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(directiveName), OutStringAt(null));
    IGqlpArg argument = ParseOk(_argumentParser);

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDirective>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        x => x.Identifier.ShouldBe(directiveName),
        x => x.Arg.ShouldBe(argument)
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenSecondDirectiveNameFails(string directiveName)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(directiveName), OutFail);
    IGqlpArg argument = ParseOk(_argumentParser);

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpDirective>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenDirectiveNameIsMissing()
  {
    // Arrange
    PrefixReturns('@', OutFail);

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenArgumentParsingFails(string directiveName, string error)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(directiveName));
    ParseError(_argumentParser, error);

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpDirective>>()
      .Result.ShouldHaveSingleItem()
      .Identifier.ShouldBe(directiveName);
  }

  [Fact]
  public void Parse_ShouldReturnEmptyArrayResult_WhenNoDirectivesAreParsed()
  {
    // Arrange
    PrefixReturns('@', OutStringAt(null));

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDirective>>()
      .Required().ShouldBeEmpty();
  }
}
