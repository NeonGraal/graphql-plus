using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputObjectsTests
  : TestObjects<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests()
    => _merger = new(TypeParameters, Alternates, Fields);

  internal override AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst> MergerObject => _merger;

  protected override OutputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override OutputFieldAst[] MakeFields(string field, string type)
    => field.OutputFields(type);
  protected override OutputReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
