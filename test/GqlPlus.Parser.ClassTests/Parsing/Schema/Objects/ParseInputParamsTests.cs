using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputParamsTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpObjBase>.I _input;
  private readonly IParserDefault _defaultParser;
  private readonly ParseInputParams _parser;

  public ParseInputParamsTests()
  {
    ConfigureRepo<IGqlpObjBase>(Parsers, out _input);
    ConfigureRepoInterface<IParserDefault, IGqlpConstant>(Parsers, out _defaultParser);
    _parser = new ParseInputParams(Parsers);
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenValid()
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
  public void Parse_ShouldReturnEmpty_WhenNoParenthesis()
  {
    // Arrange

    // Act
    IResultArray<IGqlpInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IGqlpInputParam>>();
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

  [Fact]
  public void Parse_ShouldReturnPartial_WhenModifiersError()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_input);
    ParseModifiersError();
    SetupError<IGqlpInputParam>();

    // Act
    IResultArray<IGqlpInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpInputParam>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenDefaultError()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_input);
    ParseError(_defaultParser);
    SetupError<IGqlpInputParam>();

    // Act
    IResultArray<IGqlpInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpInputParam>>();
  }
}
