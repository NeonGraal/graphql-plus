using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainRangeTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpDomainRange>.IA _itemsParser;
  private readonly ParseDomainRange _parser;

  public ParseDomainRangeTests()
  {
    Parser<IGqlpDomainRange>.DA itemsParser = ParserAFor(out _itemsParser);
    _parser = new ParseDomainRange(itemsParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainRange_WhenValid(decimal value)
  {
    // Arrange
    Tokenizer.Number(out _).Returns(OutNumber(value));

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Number(out _).Returns(OutFail);

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
