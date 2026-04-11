using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IAstObjBase>.I _parseBase;
  private readonly Parser<IAstEnumValue>.I _parseEnum;
  private readonly ParseAlternates _parser;

  public ParseAlternatesTests()
  {
    ConfigureRepo<IAstObjBase>(Parsers, out _parseBase);
    ConfigureRepo<IAstEnumValue>(Parsers, out _parseEnum);
    _parser = new ParseAlternates(Parsers);
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenBaseValid()
  {
    // Arrange
    TakeAnyReturns(OutChar('|'));
    ParseOk(_parseBase);

    // Act
    IResultArray<IAstAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEnumValid()
  {
    // Arrange
    TakeAnyReturns(OutChar('!'));
    ParseOk(_parseEnum);

    // Act
    IResultArray<IAstAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeAnyReturns(OutFail);

    // Act
    IResultArray<IAstAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstAlternate>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenBaseInvalid()
  {
    // Arrange
    TakeAnyReturns(OutChar('|'));
    ParseError(_parseBase);
    SetupPartial<IAstAlternate>();

    // Act
    IResultArray<IAstAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstAlternate>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenEnumInvalid()
  {
    // Arrange
    TakeAnyReturns(OutChar('!'));
    ParseError(_parseEnum);
    SetupPartial<IAstAlternate>();

    // Act
    IResultArray<IAstAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstAlternate>>();
  }
}
