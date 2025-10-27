using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeDualObjectsTests
  : TestObjectMerger<IGqlpDualField>
{
  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Dual)
    => MergerObject = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpDualField> MergerObject { get; }

  protected override IGqlpDualField[] MakeFields(FieldInput[]? fields)
    => fields?.DualFields() ?? [];
}
