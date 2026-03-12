using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeInputObjectsTests
  : TestObjectMerger<IGqlpInputField>
{
  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Input)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpInputField>().Returns(Fields);
    mergers.MergerFor<IGqlpTypeParam>().Returns(TypeParams);
    mergers.MergerFor<IGqlpAlternate>().Returns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IGqlpInputField> MergerObject { get; }

  protected override IGqlpInputField[] MakeFields(FieldInput[]? fields)
    => fields?.InputFields() ?? [];
}
