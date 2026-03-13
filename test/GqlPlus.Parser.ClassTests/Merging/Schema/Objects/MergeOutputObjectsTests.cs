using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputObjectsTests
  : TestObjectMerger<IGqlpOutputField>
{
  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Output)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpOutputField>().Returns(Fields);
    mergers.MergerFor<IGqlpTypeParam>().Returns(TypeParams);
    mergers.MergerFor<IGqlpAlternate>().Returns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IGqlpOutputField> MergerObject { get; }

  protected override IGqlpOutputField[] MakeFields(FieldInput[]? fields)
    => fields?.OutputFields() ?? [];
}
