using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeInputObjectsTests
  : TestObjects<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests()
    => _merger = new(TypeParameters, Alternates, Fields);

  protected override ObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst> MergerObject => _merger;

  protected override InputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override InputReferenceAst MakeReference(string type, string description = "")
    => new(AstNulls.At, type, description);
}
