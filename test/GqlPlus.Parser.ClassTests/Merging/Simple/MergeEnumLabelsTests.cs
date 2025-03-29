using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Schema;

namespace GqlPlus.Merging.Simple;

public class MergeEnumLabelsTests(
  ITestOutputHelper outputHelper
) : TestAliased<IGqlpEnumLabel>
{
  private readonly MergeEnumLabels _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpEnumLabel> MergerGroups => _merger;

  protected override IGqlpEnumLabel MakeAliased(string name, string[]? aliases = null, string description = "")
    => new EnumLabelAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
