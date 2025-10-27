using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeInputObjectsTests
  : TestObjectMerger<IGqlpInputField>
{
  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Input)
    => MergerObject = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpInputField> MergerObject { get; }

  protected override IGqlpInputField[] MakeFields(FieldInput[]? fields)
    => fields?.InputFields() ?? [];
}
