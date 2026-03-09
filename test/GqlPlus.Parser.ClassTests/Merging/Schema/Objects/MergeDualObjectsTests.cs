using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeDualObjectsTests
  : TestObjectMerger<IGqlpDualField>
{
  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Dual)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpDualField>().Returns(Fields);
    mergers.MergerFor<IGqlpTypeParam>().Returns(TypeParams);
    mergers.MergerFor<IGqlpAlternate>().Returns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IGqlpDualField> MergerObject { get; }

  protected override IGqlpDualField[] MakeFields(FieldInput[]? fields)
    => fields?.DualFields() ?? [];
}
