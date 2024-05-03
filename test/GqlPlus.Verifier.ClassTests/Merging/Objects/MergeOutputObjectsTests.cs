using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class MergeOutputObjectsTests
  : TestObjects<OutputDeclAst, OutputFieldAst, OutputBaseAst>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputBaseAst> MergerObject => _merger;

  protected override OutputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override OutputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.OutputFields();
  protected override OutputBaseAst MakeBase(string type)
    => new(AstNulls.At, type);
}
