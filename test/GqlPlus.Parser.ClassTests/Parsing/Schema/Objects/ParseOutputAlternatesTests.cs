using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpOutputBase>.I _parseBase;
  private readonly ParseOutputAlternates _parser;

  public ParseOutputAlternatesTests()
  {
    Parser<IGqlpOutputBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseOutputAlternates(Collections, parseBase);
  }

  [Fact]
  public void Parse_ShouldReturnOutputAlternate_WhenValid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseOk(_parseBase);

    // Act
    IResultArray<IGqlpOutputAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpOutputAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeReturns('|', false);

    // Act
    IResultArray<IGqlpOutputAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpOutputAlternate>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseError(_parseBase);
    SetupPartial<IGqlpOutputAlternate>();

    // Act
    IResultArray<IGqlpOutputAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpOutputAlternate>>();
  }
}
