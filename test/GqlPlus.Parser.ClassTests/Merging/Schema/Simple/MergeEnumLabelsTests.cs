using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeEnumLabelsTests(
  ITestOutputHelper outputHelper
) : TestAliasedMerger<IGqlpEnumLabel>
{
  private readonly MergeEnumLabels _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpEnumLabel> MergerGroups => _merger;

  protected override IGqlpEnumLabel MakeAliased(string name, string[]? aliases = null, string description = "")
    => new EnumLabelAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
