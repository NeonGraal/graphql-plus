using GqlPlus.Ast.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputObjectsTests
  : TestObjectMerger<IAstOutputField>
{
  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Output)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerForReturns(Fields);
    mergers.MergerForReturns(TypeParams);
    mergers.MergerForReturns(Alternates);
    MergerObject = new(mergers);
  }

  internal override AstObjectsMerger<IAstOutputField> MergerObject { get; }

  protected override IAstOutputField[] MakeFields(FieldInput[]? fields)
    => fields?.OutputFields() ?? [];
}
