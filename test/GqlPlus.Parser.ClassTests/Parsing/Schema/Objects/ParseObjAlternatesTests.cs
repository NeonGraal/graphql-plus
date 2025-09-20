using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly ParseObjAlternates _parser;

  public ParseObjAlternatesTests()
  {
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseObjAlternates(Collections, parseBase);
  }

  [Fact]
  public void Parse_ShouldReturnDualAlternate_WhenValid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseOk(_parseBase);

    // Act
    IResultArray<IGqlpObjAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeReturns('|', false);

    // Act
    IResultArray<IGqlpObjAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjAlternate>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseError(_parseBase);
    SetupPartial<IGqlpObjAlternate>();

    // Act
    IResultArray<IGqlpObjAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpObjAlternate>>();
  }
}
