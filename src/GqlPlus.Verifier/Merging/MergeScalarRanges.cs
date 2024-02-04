using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRanges
  : AstScalarItemMerger<ScalarRangeAst>
{
  protected override string ItemGroupKey(ScalarRangeAst item)
    => item.GetFields().Skip(2).Joined();
}
