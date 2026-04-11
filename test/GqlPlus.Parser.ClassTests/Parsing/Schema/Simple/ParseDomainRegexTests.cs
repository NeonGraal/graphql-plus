using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainRegexTests
  : ParseDomainClassTestBase<IAstDomainRegex>
{
  public ParseDomainRegexTests()
    : base(DomainKind.String)
  { }

  protected override void ArrangeValidItem()
    => Tokenizer.Regex(out _).Returns(OutString(".*"));

  protected override IAstDomainRegex NewItem()
    => new DomainRegexAst(AstNulls.At, string.Empty, false, "*");

  internal override ParseDomainItem<IAstDomainRegex> MakeParser(IParserRepository parsers)
    => new ParseDomainRegex(parsers);
}
