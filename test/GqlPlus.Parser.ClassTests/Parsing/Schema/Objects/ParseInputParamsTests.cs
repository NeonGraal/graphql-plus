using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputParamsTests
  : ModifiersClassTestBase
{
  private readonly Parser<IAstObjBase>.I _input;
  private readonly IParserDefault _defaultParser;
  private readonly ParseInputParams _parser;

  public ParseInputParamsTests()
  {
    ConfigureRepo<IAstObjBase>(Parsers, out _input);
    ConfigureRepoInterface<IParserDefault, IAstConstant>(Parsers, out _defaultParser);
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
    IResultArray<IAstInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstInputParam>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoParenthesis()
  {
    // Arrange

    // Act
    IResultArray<IAstInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IAstInputParam>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoInputParams()
  {
    // Arrange
    TakeReturns('(', true);
    ParseError(_input);
    SetupError<IAstInputParam>();

    // Act
    IResultArray<IAstInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IAstInputParam>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenModifiersError()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_input);
    ParseModifiersError();
    SetupError<IAstInputParam>();

    // Act
    IResultArray<IAstInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstInputParam>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenDefaultError()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_input);
    ParseError(_defaultParser);
    SetupError<IAstInputParam>();

    // Act
    IResultArray<IAstInputParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstInputParam>>();
  }
}
