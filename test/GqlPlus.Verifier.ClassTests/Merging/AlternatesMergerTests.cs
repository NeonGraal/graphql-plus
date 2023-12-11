using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class AlternatesMergerTests
  : TestAlternates<OutputReferenceAst>
{
  private readonly AlternatesMerger<OutputReferenceAst> _merger = new();

  protected override AlternatesMerger<AlternateAst<OutputReferenceAst>, OutputReferenceAst> MergerAlternate => _merger;

  protected override AlternateAst<OutputReferenceAst> MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new OutputReferenceAst(AstNulls.At, name, description));
}
