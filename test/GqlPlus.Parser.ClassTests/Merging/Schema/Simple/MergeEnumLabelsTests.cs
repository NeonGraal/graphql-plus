using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeEnumLabelsTests(ITestOutputHelper outputHelper)
    : TestAliasedMerger<IAstEnumLabel>
{
  private readonly MergeEnumLabels _merger = new(MergeRepo(outputHelper.ToLoggerFactory()));

  internal override GroupsMerger<IAstEnumLabel> MergerGroups => _merger;

  protected override IAstEnumLabel MakeAliased(string name, string[]? aliases = null, string description = "")
    => new EnumLabelAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
