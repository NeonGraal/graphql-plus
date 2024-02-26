using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputObjectsTests
  : TestObjects<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests()
    => _merger = new(Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst> MergerObject => _merger;

  protected override OutputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override OutputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.OutputFields();
  protected override OutputReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
