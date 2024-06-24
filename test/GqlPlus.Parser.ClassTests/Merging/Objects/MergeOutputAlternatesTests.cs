using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeOutputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger<IGqlpOutputAlternate, IGqlpOutputBase>
{
  private readonly MergeOutputAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeOutputAlternatesChecks _checks = new();

  internal override AstAlternatesMerger<IGqlpOutputAlternate> MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpOutputAlternate> CheckAlternates => _checks;
}

internal class MergeOutputAlternatesChecks
  : CheckAlternatesMerger<IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase>
{
  public override IGqlpOutputAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new OutputAlternateAst(AstNulls.At, new OutputBaseAst(AstNulls.At, input, description)) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
