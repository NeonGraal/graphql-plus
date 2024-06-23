using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualFieldsTests(
  ITestOutputHelper outputHelper
) : TestObjectFields<IGqlpDualField, DualFieldAst, IGqlpDualBase>
{
  private readonly MergeDualFields _merger = new(outputHelper.ToLoggerFactory());

  internal override AstObjectFieldsMerger<IGqlpDualField> MergerField => _merger;

  protected override DualFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new DualBaseAst(AstNulls.At, type, typeDescription));
}
