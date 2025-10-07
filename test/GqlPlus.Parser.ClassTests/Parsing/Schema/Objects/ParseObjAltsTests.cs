using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjAltsTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly Parser<IGqlpEnumValue>.I _parseEnum;
  private readonly ParseObjAlts _parser;

  public ParseObjAltsTests()
  {
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    Parser<IGqlpEnumValue>.D parseEnum = ParserFor(out _parseEnum);
    _parser = new ParseObjAlts(Collections, parseBase, parseEnum);
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenBaseValid()
  {
    // Arrange
    TakeAnyReturns(OutChar('|'));
    ParseOk(_parseBase);

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjAlt>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEnumValid()
  {
    // Arrange
    TakeAnyReturns(OutChar('!'));
    ParseOk(_parseEnum);

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjAlt>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeAnyReturns(OutFail);

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjAlt>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenBaseInvalid()
  {
    // Arrange
    TakeAnyReturns(OutChar('|'));
    ParseError(_parseBase);
    SetupPartial<IGqlpObjAlt>();

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpObjAlt>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenEnumInvalid()
  {
    // Arrange
    TakeAnyReturns(OutChar('!'));
    ParseError(_parseEnum);
    SetupPartial<IGqlpObjAlt>();

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpObjAlt>>();
  }
}
