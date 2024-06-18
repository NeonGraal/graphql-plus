using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeInputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternates<IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase>
{
  private readonly MergeInputAlternates _merger = new(outputHelper.ToLoggerFactory());

  internal override AstAlternatesMerger<IGqlpInputAlternate, IGqlpInputBase> MergerAlternate => _merger;

  protected override InputAlternateAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new InputBaseAst(AstNulls.At, name, description));
}
