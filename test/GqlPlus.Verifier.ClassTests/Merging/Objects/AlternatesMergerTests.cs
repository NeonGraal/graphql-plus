using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class AlternatesMergerTests(
  ITestOutputHelper outputHelper
) : TestAlternates<OutputReferenceAst>
{
  private readonly AlternatesMerger<OutputReferenceAst> _merger = new(outputHelper.ToLoggerFactory());

  internal override AstAlternatesMerger<AstAlternate<OutputReferenceAst>, OutputReferenceAst> MergerAlternate => _merger;

  protected override AstAlternate<OutputReferenceAst> MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new OutputReferenceAst(AstNulls.At, name, description));
}
