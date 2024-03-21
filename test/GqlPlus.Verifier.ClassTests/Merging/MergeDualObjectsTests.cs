using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeDualObjectsTests
  : TestObjects<DualDeclAst, DualFieldAst, DualReferenceAst>
{
  private readonly MergeDualObjects _merger;

  public MergeDualObjectsTests()
    => _merger = new(Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<DualDeclAst, DualFieldAst, DualReferenceAst> MergerObject => _merger;

  protected override DualDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override DualFieldAst[] MakeFields(FieldInput[] fields)
    => fields.DualFields();
  protected override DualReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
