using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class MergeDualFieldsTests(
  ITestOutputHelper outputHelper
) : TestFields<DualFieldAst, DualReferenceAst>
{
  private readonly MergeDualFields _merger = new(outputHelper.ToLoggerFactory());

  internal override FieldsMerger<DualFieldAst, DualReferenceAst> MergerField => _merger;

  protected override DualFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}
