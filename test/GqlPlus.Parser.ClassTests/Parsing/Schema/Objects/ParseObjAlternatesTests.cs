using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly ParseObjAlts _parser;

  public ParseObjAlternatesTests()
  {
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseObjAlts(Collections, parseBase);
  }

  [Fact]
  public void Parse_ShouldReturnDualAlternate_WhenValid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseOk(_parseBase);

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
    TakeReturns('|', false);

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjAlt>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseError(_parseBase);
    SetupPartial<IGqlpObjAlt>();

    // Act
    IResultArray<IGqlpObjAlt> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpObjAlt>>();
  }
}
