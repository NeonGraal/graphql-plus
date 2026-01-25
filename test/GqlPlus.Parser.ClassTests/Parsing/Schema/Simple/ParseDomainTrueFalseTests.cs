using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainTrueFalseTests
  : ParseDomainClassTestBase<IGqlpDomainTrueFalse>
{

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNotBoolean()
  {
    // Arrange
    IdentifierReturns(OutString("phish"));
    SetupPartial<IGqlpDomainTrueFalse>();

    // Act
    IResult<IGqlpDomainTrueFalse> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainTrueFalse>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNothingAfterExclamation()
  {
    // Arrange
    TakeReturns('!', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpDomainTrueFalse>();

    // Act
    IResult<IGqlpDomainTrueFalse> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainTrueFalse>>();
  }

  [Fact]
  public void ParseItems_ShouldReturnDefault_WhenEmpty()
  {
    // Arrange
    TakeReturns('}', true);
    DomainDefinition initial = new() { Kind = DomainKind.Boolean };
    ParseOkA(ItemsParser, []);

    // Act
    IResult<DomainDefinition> result = Parser.Parser(Tokenizer, TestLabel, initial);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainDefinition>>();
  }

  public ParseDomainTrueFalseTests()
    : base(DomainKind.Boolean)
  { }

  internal override ParseDomainItem<IGqlpDomainTrueFalse> MakeParser(Parser<IGqlpDomainTrueFalse>.DA itemsParser)
    => new ParseDomainTrueFalse(itemsParser);
  protected override IGqlpDomainTrueFalse NewItem()
    => new DomainTrueFalseAst(AstNulls.At, string.Empty, false, false);

  protected override void ArrangeValidItem()
    => IdentifierReturns(OutString(BuiltIn.BooleanTrue));
}
