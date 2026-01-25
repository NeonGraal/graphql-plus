using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainTrueFalseTests
  : ParseDomainClassTestBase<IGqlpDomainTrueFalse>
{
  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNotBoolean(string label)
  {
    // Arrange
    IdentifierReturns(OutString("phish"));
    SetupPartial<IGqlpDomainTrueFalse>();

    // Act
    IResult<IGqlpDomainTrueFalse> result = Parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainTrueFalse>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNothingAfterExclamation(string label)
  {
    // Arrange
    TakeReturns('!', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpDomainTrueFalse>();

    // Act
    IResult<IGqlpDomainTrueFalse> result = Parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainTrueFalse>>();
  }

  [Theory, RepeatData]
  public void ParseItems_ShouldReturnDefault_WhenEmpty(string label)
  {
    // Arrange
    TakeReturns('}', true);
    DomainDefinition initial = new() { Kind = DomainKind.Boolean };
    ParseOkA(ItemsParser, []);

    // Act
    IResult<DomainDefinition> result = Parser.Parser(Tokenizer, label, initial);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainDefinition>>();
  }

  public ParseDomainTrueFalseTests()
    : base(DomainKind.Boolean)
  { }

  internal override ParseDomainItem<IGqlpDomainTrueFalse> MakeParser(Parser<IGqlpDomainTrueFalse>.DA itemsParser)
    => new ParseDomainTrueFalse(itemsParser);
  protected override IGqlpDomainTrueFalse NewItem()
    => new DomainTrueFalseAst(AstNulls.At, "", false, false);

  protected override void ArrangeValidItem()
    => IdentifierReturns(OutString(BuiltIn.BooleanTrue));
}
