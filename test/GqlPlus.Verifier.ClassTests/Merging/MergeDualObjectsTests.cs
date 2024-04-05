using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeDualObjectsTests
  : TestObjects<DualDeclAst, DualFieldAst, DualReferenceAst>
{
  private readonly MergeDualObjects _merger;

  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<DualDeclAst, DualFieldAst, DualReferenceAst> MergerObject => _merger;

  protected override DualDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override DualFieldAst[] MakeFields(FieldInput[] fields)
    => fields.DualFields();
  protected override DualReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
