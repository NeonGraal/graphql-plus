using GqlPlus.Ast.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeInputObjectsTests
  : TestObjectMerger<IAstInputField>
{
  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Input)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerForReturns(Fields);
    mergers.MergerForReturns(TypeParams);
    mergers.MergerForReturns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IAstInputField> MergerObject { get; }

  protected override IAstInputField[] MakeFields(FieldInput[]? fields)
    => fields?.InputFields() ?? [];
}
