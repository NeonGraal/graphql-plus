using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Types;

public class MergeScalarAstStringsTests(
  ITestOutputHelper outputHelper
) : TestScalarAsts<ScalarRegexAst, string>(outputHelper)
{
  protected override ScalarRegexAst[] MakeItems(string input)
    => new[] { input }.ScalarRegexes();

  protected override AstScalar<ScalarRegexAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarDomain.String);
}
