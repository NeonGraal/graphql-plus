using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger<IGqlpOutputAlternate, IGqlpOutputBase>
{
  private readonly MergeOutputAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeOutputAlternatesChecks _checks = new();

  internal override AstAlternatesMerger<IGqlpOutputAlternate> MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpOutputAlternate> CheckAlternates => _checks;
}

internal sealed class MergeOutputAlternatesChecks
  : CheckAlternatesMerger<IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputArg>
{
  public override IGqlpOutputAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new OutputAlternateAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
