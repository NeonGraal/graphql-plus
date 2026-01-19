using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainRangeTests
  : ParseDomainClassTestBase<IGqlpDomainRange>
{
  [Theory, RepeatData]
  public void Parse_ValieSingleRange_ThenOk(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBe(value),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ValidLowerRange_ThenOk(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeReturns('>', true);

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(value),
        r => r.Upper.ShouldBeNull(),
        r => r.Excludes.ShouldBeFalse());
  }

  [Theory, RepeatData]
  public void Parse_ValidUpperRange_ThenOk(decimal value)
  {
    // Arrange
    NumberReturns(OutNumber(value));
    TakeReturns('<', true);

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBeNull(),
        r => r.Upper.ShouldBe(value),
        r => r.Excludes.ShouldBeFalse());
  }

  [Fact]
  public void Parse_InvalidLowerRange_ThenError()
  {
    // Arrange
    TakeReturns('>', true);
    SetupError<IGqlpDomainRange>();

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_InvalidUpperRange_ThenError()
  {
    // Arrange
    TakeReturns('<', true);
    SetupError<IGqlpDomainRange>();

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ValidRange_ThenOk(decimal first, decimal second)
  {
    // Arrange
    TakeReturns('~', true);

    (decimal lower, decimal upper) = (first, second);

    if (first > second) {
      (lower, upper) = (second, first);
    }

    NumberReturns(OutNumber(lower), OutNumber(upper));

    // Act
    IResult<IGqlpDomainRange> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRange>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.Lower.ShouldBe(lower),
        r => r.Upper.ShouldBe(upper),
        r => r.Excludes.ShouldBeFalse());
  }

  public ParseDomainRangeTests()
    : base(DomainKind.Number)
  { }

  internal override ParseDomainItem<IGqlpDomainRange> MakeParser(Parser<IGqlpDomainRange>.DA itemsParser)
    => new ParseDomainRange(itemsParser);

  protected override IGqlpDomainRange NewItem()
    => new DomainRangeAst(AstNulls.At, "", false);

  protected override void ArrangeValidItem()
    => NumberReturns(OutNumber(42));
}
