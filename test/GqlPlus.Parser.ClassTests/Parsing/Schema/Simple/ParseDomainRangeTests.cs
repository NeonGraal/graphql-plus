using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainRangeTests
  : ParseDomainClassTestBase<IGqlpDomainRange>
{
  [Theory, RepeatData]
  public void Parse_ValidSingleRange_ReturnsCorrect(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBe(value),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ValidBeforeLowerRange_ReturnsCorrect(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeAnyReturns(OutChar('>'));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBeNull(),
        r => r.Excludes.ShouldBeFalse());
  }

  [Fact]
  public void Parse_InvalidBeforeLowerRange_ReturnsError()
  {
    // Arrange
    TakeAnyReturns(OutChar('>'));
    SetupError<IGqlpDomainRange>();

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ValidAfterLowerRange_ReturnsCorrect(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeAnyReturns(OutFail, OutChar('<'));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBeNull(),
        r => r.Excludes.ShouldBeFalse());
  }

  [Fact]
  public void Parse_InvalidAfterLowerRange_ReturnsError()
  {
    // Arrange
    TakeAnyReturns(OutFail, OutChar('<'));
    SetupError<IGqlpDomainRange>();

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ValidBeforeUpperRange_ReturnsCorrect(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeAnyReturns(OutChar('<'));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBeNull(),
        r => r.Upper.ShouldBe(value),
        r => r.Excludes.ShouldBeFalse());
  }

  [Fact]
  public void Parse_InvalidBeforeUpperRange_ReturnsError()
  {
    // Arrange
    TakeAnyReturns(OutChar('<'));
    SetupError<IGqlpDomainRange>();

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ValidAfterUpperRange_ReturnsCorrect(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeAnyReturns(OutFail, OutChar('<'));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBeNull(),
        r => r.Excludes.ShouldBeFalse());
  }

  [Fact]
  public void Parse_InvalidAfterUpperRange_ReturnsError()
  {
    // Arrange
    TakeAnyReturns(OutFail, OutChar('>'));
    SetupError<IGqlpDomainRange>();

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ValidPositiveRange_ReturnsCorrect(decimal first, decimal second)
  {
    // Arrange
    TakeAnyReturns(OutFail, OutChar('<'));

    (decimal lower, decimal upper) = (first, second);

    if (first > second) {
      (lower, upper) = (second, first);
    }

    NumberReturns(OutNumber(lower), OutNumber(upper));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(lower),
        r => r.Upper.ShouldBe(upper),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ValidNegativeRange_ReturnsCorrect(decimal first, decimal second)
  {
    // Arrange
    TakeAnyReturns(OutFail, OutChar('>'));

    (decimal lower, decimal upper) = (first, second);

    if (first > second) {
      (lower, upper) = (second, first);
    }

    NumberReturns(OutNumber(lower), OutNumber(upper));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(upper),
        r => r.Upper.ShouldBe(lower),
        r => r.Excludes.ShouldBeFalse());
  }

  public ParseDomainRangeTests()
    : base(DomainKind.Number)
  { }

  internal override ParseDomainItem<IGqlpDomainRange> MakeParser(Parser<IGqlpDomainRange>.DA itemsParser)
    => new ParseDomainRange(itemsParser);

  protected override IGqlpDomainRange NewItem()
    => new DomainRangeAst(AstNulls.At, string.Empty, false);

  protected override void ArrangeValidItem()
    => NumberReturns(OutNumber(42));
}
