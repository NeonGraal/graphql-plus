using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputParamsTests
  : AliasesClassTestBase
{
  private readonly Parser<IGqlpInputBase>.I _input;
  private readonly Parser<IGqlpConstant>.I _defaultParser;
  private readonly ParseInputParams _parser;

  public ParseInputParamsTests()
  {
    Parser<IGqlpInputBase>.D input = ParserFor(out _input);
    Parser<IParserDefault, IGqlpConstant>.D defaultParser = ParserFor<IParserDefault, IGqlpConstant>(out _defaultParser);
    _parser = new ParseInputParams(input, Modifiers, defaultParser);
  }

  [Fact]
  public void Parse_ShouldReturnInputParams_WhenValid()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_input);
    ParseOk(_defaultParser);
    TakeReturns(')', false, true);

    // Act
    IResultArray<IGqlpInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpInputParam>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoInputParams()
  {
    // Arrange
    TakeReturns('(', true);
    ParseError(_input);
    SetupError<IGqlpInputParam>();

    // Act
    IResultArray<IGqlpInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpInputParam>>();
  }
}
