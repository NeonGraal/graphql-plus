using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public class MergeInputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger<IGqlpInputAlternate, IGqlpInputBase>
{
  private readonly MergeInputAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeInputAlternatesChecks _checks = new();

  internal override AstAlternatesMerger<IGqlpInputAlternate> MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpInputAlternate> CheckAlternates => _checks;
}

internal sealed class MergeInputAlternatesChecks
  : CheckAlternatesMerger<IGqlpInputAlternate, InputAlternateAst, IGqlpInputArg>
{
  public override IGqlpInputAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new InputAlternateAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
