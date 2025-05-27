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
  public void Parse_ShouldSingleRange_WhenValid(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBe(value),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ShouldLowerRange_WhenValid(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeReturns('>', true);

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBeNull(),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ShouldUpperRange_WhenValid(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeReturns('<', true);

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBeNull(),
        r => r.Upper.ShouldBe(value),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ShouldRange_WhenValid(decimal first, decimal second)
  {
    // Arrange
    TakeReturns('~', true);

    (decimal lower, decimal upper) = (first, second);

    if (first > second) {
      (lower, upper) = (second, first);
    }

    NumberReturns(OutNumber(lower), OutNumber(upper));

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(lower),
        r => r.Upper.ShouldBe(upper),
        r => r.Excludes.ShouldBeFalse());
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    NumberReturns(OutFail);

    // Act
    IResult<IGqlpDomainRange> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
