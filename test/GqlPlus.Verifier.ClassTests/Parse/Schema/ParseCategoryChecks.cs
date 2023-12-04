using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseCategoryChecks
  : BaseAliasedParserChecks<string, CategoryAst>
{
  public ParseCategoryChecks(Parser<CategoryAst>.D parser)
    : base(parser) { }

  protected internal override CategoryAst AliasedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => aliases + "{" + input + "}";
}
