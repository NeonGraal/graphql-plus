using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class AlternatesMergerTests(
  ITestOutputHelper outputHelper
) : TestAlternates<OutputBaseAst>
{
  private readonly AlternatesMerger<OutputBaseAst> _merger = new(outputHelper.ToLoggerFactory());

  internal override AstAlternatesMerger<AstAlternate<OutputBaseAst>, OutputBaseAst> MergerAlternate => _merger;

  protected override AstAlternate<OutputBaseAst> MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new OutputBaseAst(AstNulls.At, name, description));
}
