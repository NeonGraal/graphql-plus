using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseCategoryChecks
  : BaseAliasedParserChecks<string, CategoryDeclAst>
{
  public ParseCategoryChecks(Parser<CategoryDeclAst>.D parser)
    : base(parser) { }

  protected internal override CategoryDeclAst AliasedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => aliases + "{" + input + "}";
}
