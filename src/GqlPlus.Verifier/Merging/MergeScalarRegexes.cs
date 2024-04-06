using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes(
  ILoggerFactory logger
) : AstScalarItemMerger<ScalarRegexAst>(logger)
{
  protected override string ItemMatchName => "Regex";
  protected override string ItemGroupKey(ScalarRegexAst item)
    => item.Regex;
}
