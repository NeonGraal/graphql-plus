using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainRegexTests
  : ParseDomainClassTestBase<IGqlpDomainRegex>
{
  public ParseDomainRegexTests()
    : base(DomainKind.String)
  { }

  protected override void ArrangeValidItem()
    => Tokenizer.Regex(out _).Returns(OutString(".*"));

  protected override IGqlpDomainRegex NewItem()
    => new DomainRegexAst(AstNulls.At, string.Empty, false, "*");

  internal override ParseDomainItem<IGqlpDomainRegex> MakeParser(Parser<IGqlpDomainRegex>.DA itemsParser)
    => new ParseDomainRegex(itemsParser);
}
