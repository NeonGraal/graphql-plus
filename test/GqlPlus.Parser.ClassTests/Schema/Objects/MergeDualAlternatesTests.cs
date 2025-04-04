using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Schema.Objects;

public class MergeDualAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger<IGqlpDualAlternate, IGqlpDualBase>
{
  private readonly MergeDualAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeDualAlternatesChecks _checks = new();

  internal override AstAlternatesMerger<IGqlpDualAlternate> MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpDualAlternate> CheckAlternates => _checks;
}

internal sealed class MergeDualAlternatesChecks
  : CheckAlternatesMerger<IGqlpDualAlternate, DualAlternateAst, IGqlpDualArg>
{
  public override IGqlpDualAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new DualAlternateAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
