using System.Xml.Linq;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternatesMerger<IGqlpDualAlternate, IGqlpDualBase>
{
  private readonly MergeDualAlternates _merger = new(outputHelper.ToLoggerFactory());
  private readonly MergeDualAlternatesChecks _checks = new();

  internal override AstAlternatesMerger<IGqlpDualAlternate> MergerAlternate => _merger;
  internal override ICheckAlternatesMerger<IGqlpDualAlternate> CheckAlternates => _checks;
}

internal class MergeDualAlternatesChecks
  : CheckAlternatesMerger<IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase>
{
  public override IGqlpDualAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new DualAlternateAst(AstNulls.At, new DualBaseAst(AstNulls.At, input, description)) {
      Modifiers = withModifiers ? TestMods() : []
    };
}
