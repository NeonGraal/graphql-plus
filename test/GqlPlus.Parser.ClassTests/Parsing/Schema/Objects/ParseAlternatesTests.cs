using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly Parser<IGqlpEnumValue>.I _parseEnum;
  private readonly ParseAlternates _parser;

  public ParseAlternatesTests()
  {
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    Parser<IGqlpEnumValue>.D parseEnum = ParserFor(out _parseEnum);
    _parser = new ParseAlternates(Collections, parseBase, parseEnum);
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenBaseValid()
  {
    // Arrange
    TakeAnyReturns(OutChar('|'));
    ParseOk(_parseBase);

    // Act
    IResultArray<IGqlpAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEnumValid()
  {
    // Arrange
    TakeAnyReturns(OutChar('!'));
    ParseOk(_parseEnum);

    // Act
    IResultArray<IGqlpAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeAnyReturns(OutFail);

    // Act
    IResultArray<IGqlpAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpAlternate>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenBaseInvalid()
  {
    // Arrange
    TakeAnyReturns(OutChar('|'));
    ParseError(_parseBase);
    SetupPartial<IGqlpAlternate>();

    // Act
    IResultArray<IGqlpAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpAlternate>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenEnumInvalid()
  {
    // Arrange
    TakeAnyReturns(OutChar('!'));
    ParseError(_parseEnum);
    SetupPartial<IGqlpAlternate>();

    // Act
    IResultArray<IGqlpAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpAlternate>>();
  }
}
