using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeInputObjectsTests
  : TestObjectMerger<IAstInputField>
{
  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Input)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstInputField>().Returns(Fields);
    mergers.MergerFor<IAstTypeParam>().Returns(TypeParams);
    mergers.MergerFor<IAstAlternate>().Returns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IAstInputField> MergerObject { get; }

  protected override IAstInputField[] MakeFields(FieldInput[]? fields)
    => fields?.InputFields() ?? [];
}
