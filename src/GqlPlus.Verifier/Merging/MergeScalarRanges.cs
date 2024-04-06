using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRanges(
  ILoggerFactory logger
) : AstScalarItemMerger<ScalarRangeAst>(logger)
{
  protected override string ItemMatchName => "Range";
  protected override string ItemGroupKey(ScalarRangeAst item)
    => item.GetFields().Skip(2).Joined();
}
