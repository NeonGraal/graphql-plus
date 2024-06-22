using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeOutputAlternatesTests(
  ITestOutputHelper outputHelper
) : TestAlternates<IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase>
{
  private readonly MergeOutputAlternates _merger = new(outputHelper.ToLoggerFactory());

  internal override AstAlternatesMerger<IGqlpOutputAlternate> MergerAlternate => _merger;

  protected override OutputAlternateAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new OutputBaseAst(AstNulls.At, name, description));
}
