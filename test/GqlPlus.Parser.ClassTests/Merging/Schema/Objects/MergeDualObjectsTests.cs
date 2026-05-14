using GqlPlus.Ast.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeDualObjectsTests
  : TestObjectMerger<IAstDualField>
{
  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Dual)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerForReturns(Fields);
    mergers.MergerForReturns(TypeParams);
    mergers.MergerForReturns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IAstDualField> MergerObject { get; }

  protected override IAstDualField[] MakeFields(FieldInput[]? fields)
    => fields?.DualFields() ?? [];
}
