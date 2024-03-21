using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstStringsTests
  : TestScalarAsts<ScalarRegexAst, string>
{
  protected override ScalarRegexAst[] MakeItems(string input)
    => new[] { input }.ScalarRegexes();

  protected override AstScalar<ScalarRegexAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarDomain.String);
}
