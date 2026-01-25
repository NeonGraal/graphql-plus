using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainLabelTests
  : ParseDomainClassTestBase<IGqlpDomainLabel>
{

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidJustLabel(string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IGqlpDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidTypeAndLabel(string enumType, string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumType), OutString(enumLabel));
    TakeReturns('.', true);

    // Act
    IResult<IGqlpDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidTypeAndAsterisk(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);
    TakeReturns('*', true);

    // Act
    IResult<IGqlpDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldPartial_WhenInvalidTypeAndOther(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);
    SetupPartial<IGqlpDomainLabel>();

    // Act
    IResult<IGqlpDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainLabel>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNothingAfterExclamation()
  {
    // Arrange
    TakeReturns('!', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpDomainLabel>();

    // Act
    IResult<IGqlpDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainLabel>>();
  }

  public ParseDomainLabelTests()
    : base(DomainKind.Enum)
  { }

  internal override ParseDomainItem<IGqlpDomainLabel> MakeParser(Parser<IGqlpDomainLabel>.DA itemsParser)
    => new ParseDomainLabel(itemsParser);

  protected override IGqlpDomainLabel NewItem()
    => new DomainLabelAst(AstNulls.At, string.Empty, false, itemLabel);

  protected override void ArrangeValidItem()
    => IdentifierReturns(OutString(itemLabel));

  private readonly string itemLabel = TestLabel;
}
