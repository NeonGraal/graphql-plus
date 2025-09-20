using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger
{
  private readonly MergeAstAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeOutputAlternatesChecks _checks = new();

  internal override MergeAstAlternates MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpObjAlternate> CheckAlternates => _checks;
}

internal sealed class MergeOutputAlternatesChecks
  : CheckAlternatesMerger<OutputAlternateAst>
{
  public override IGqlpObjAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new OutputAlternateAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
