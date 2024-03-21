using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeDualFieldsTests
  : TestFields<DualFieldAst, DualReferenceAst>
{
  private readonly MergeDualFields _merger = new();

  internal override FieldsMerger<DualFieldAst, DualReferenceAst> MergerField => _merger;

  protected override DualFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}
