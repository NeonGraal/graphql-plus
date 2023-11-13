using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseCategoryChecks
  : BaseAliasedChecks<string, CategoryAst>
{
  public ParseCategoryChecks()
    : base(parser => parser.ParseCategoryDeclaration(""))
  { }

  protected internal override CategoryAst AliasedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => aliases + "{" + input + "}";
}
