using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpDualBase>.I _parseBase;
  private readonly ParseDualAlternates _parser;

  public ParseDualAlternatesTests()
  {
    Parser<IGqlpDualBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseDualAlternates(Collections, parseBase);
  }

  [Fact]
  public void Parse_ShouldReturnDualAlternate_WhenValid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseOk(_parseBase);

    // Act
    IResultArray<IGqlpDualAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDualAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeReturns('|', false);

    // Act
    IResultArray<IGqlpDualAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDualAlternate>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseError(_parseBase);
    SetupPartial<IGqlpDualAlternate>();

    // Act
    IResultArray<IGqlpDualAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpDualAlternate>>();
  }
}
