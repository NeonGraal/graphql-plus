using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarReferencesTests
  : TestGroups<ScalarReferenceAst>
{
  private readonly MergeScalarReferences _merger = new();

  internal override GroupsMerger<ScalarReferenceAst> MergerGroups => _merger;

  protected override ScalarReferenceAst MakeAst(string input)
    => new(AstNulls.At, input);
}
