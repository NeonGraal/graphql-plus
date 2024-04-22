using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class MergeInputObjectsTests
  : TestObjects<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst> MergerObject => _merger;

  protected override InputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override InputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.InputFields();
  protected override InputReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
