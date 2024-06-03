using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class AlternatesMergerTests(
  ITestOutputHelper outputHelper
) : TestAlternates<IGqlpOutputBase>
{
  private readonly AlternatesMerger<IGqlpOutputBase> _merger = new(outputHelper.ToLoggerFactory());

  internal override AstAlternatesMerger<AstAlternate<IGqlpOutputBase>, IGqlpOutputBase> MergerAlternate => _merger;

  protected override AstAlternate<IGqlpOutputBase> MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new OutputBaseAst(AstNulls.At, name, description));
}
