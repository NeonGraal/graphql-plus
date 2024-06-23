using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternates<IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase>
{
  private readonly MergeDualAlternates _merger = new(outputHelper.ToLoggerFactory());

  internal override AstAlternatesMerger<IGqlpDualAlternate> MergerAlternate => _merger;

  protected override DualAlternateAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new DualBaseAst(AstNulls.At, name, description));
}
