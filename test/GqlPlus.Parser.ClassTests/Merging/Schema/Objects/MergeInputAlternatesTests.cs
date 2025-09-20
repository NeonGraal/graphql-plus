using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeInputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger
{
  private readonly MergeAstAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeInputAlternatesChecks _checks = new();

  internal override MergeAstAlternates MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpObjAlternate> CheckAlternates => _checks;
}

internal sealed class MergeInputAlternatesChecks
  : CheckAlternatesMerger<InputAlternateAst>
{
  public override IGqlpObjAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new InputAlternateAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
