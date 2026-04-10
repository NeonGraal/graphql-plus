using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainLabelTests
  : ParseDomainClassTestBase<IAstDomainLabel>
{

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidJustLabel(string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IAstDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidTypeAndLabel(string enumType, string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumType), OutString(enumLabel));
    TakeReturns('.', true);

    // Act
    IResult<IAstDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidTypeAndAsterisk(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);
    TakeReturns('*', true);

    // Act
    IResult<IAstDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldPartial_WhenInvalidTypeAndOther(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);
    SetupPartial<IAstDomainLabel>();

    // Act
    IResult<IAstDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstDomainLabel>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNothingAfterExclamation()
  {
    // Arrange
    TakeReturns('!', true);
    IdentifierReturns(OutFail);
    SetupPartial<IAstDomainLabel>();

    // Act
    IResult<IAstDomainLabel> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstDomainLabel>>();
  }

  public ParseDomainLabelTests()
    : base(DomainKind.Enum)
  { }

  internal override ParseDomainItem<IAstDomainLabel> MakeParser(IParserRepository parsers)
    => new ParseDomainLabel(parsers);

  protected override IAstDomainLabel NewItem()
    => new DomainLabelAst(AstNulls.At, string.Empty, false, _itemLabel);

  protected override void ArrangeValidItem()
    => IdentifierReturns(OutString(_itemLabel));

  private readonly string _itemLabel = TestLabel;
}
