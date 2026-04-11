using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseDirectivesTests
  : ParserClassTestBase
{

  private readonly ParseDirectives _parseDirectives;
  private readonly IParserArg _argumentParser;

  public ParseDirectivesTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoInterface<IParserArg, IAstArg>(parsers, out _argumentParser);
    _parseDirectives = new ParseDirectives(parsers);

    SetupError<IAstDirective>();
    SetupPartial<IAstDirective>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDirectivesArray_WhenDirectivesAreParsed(string directiveName)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(directiveName), OutStringAt(null));
    IAstArg argument = ParseOk(_argumentParser);

    // Act
    IResultArray<IAstDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstDirective>>()
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
    IAstArg argument = ParseOk(_argumentParser);

    // Act
    IResultArray<IAstDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstDirective>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenDirectiveNameIsMissing()
  {
    // Arrange
    PrefixReturns('@', OutFail);

    // Act
    IResultArray<IAstDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

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
    IResultArray<IAstDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstDirective>>()
      .Result.ShouldHaveSingleItem()
      .Identifier.ShouldBe(directiveName);
  }

  [Fact]
  public void Parse_ShouldReturnEmptyArrayResult_WhenNoDirectivesAreParsed()
  {
    // Arrange
    PrefixReturns('@', OutStringAt(null));

    // Act
    IResultArray<IAstDirective> result = _parseDirectives.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstDirective>>()
      .Required().ShouldBeEmpty();
  }
}
