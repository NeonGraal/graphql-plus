using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseDirectivesTests
  : ParserClassTestBase
{
  private readonly ParseDirectives _parseDirectives;
  private readonly Parser<IGqlpArg>.I _argumentParser;

  public ParseDirectivesTests()
  {
    Parser<IParserArg, IGqlpArg>.D argumentParser = ParserFor<IParserArg, IGqlpArg>(out _argumentParser);
    _parseDirectives = new ParseDirectives(argumentParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDirectivesArray_WhenDirectivesAreParsed(string directiveName)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(directiveName), OutStringAt(null));
    IGqlpArg argument = ParseOk(_argumentParser);

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDirective>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        x => x.Identifier.ShouldBe(directiveName),
        x => x.Arg.ShouldBe(argument)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenDirectiveNameIsMissing()
  {
    // Arrange
    PrefixReturns('@', OutFail);
    SetupError<IGqlpDirective>("identifier after '@'");

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenArgumentParsingFails(string directiveName)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(directiveName));
    ParseError(_argumentParser, "argument error");
    SetupPartial<IGqlpDirective>("argument error");

    // Act
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, "testLabel");

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
    IResultArray<IGqlpDirective> result = _parseDirectives.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDirective>>()
      .Required().ShouldBeEmpty();
  }
}
