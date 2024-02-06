using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeInputObjectsTests
  : TestObjects<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests()
    => _merger = new(Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst> MergerObject => _merger;

  protected override InputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override InputFieldAst[] MakeFields(string field, string type)
    => field.InputFields(type);
  protected override InputReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
