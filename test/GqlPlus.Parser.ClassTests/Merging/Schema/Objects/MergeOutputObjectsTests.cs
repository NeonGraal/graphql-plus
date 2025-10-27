using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputObjectsTests
  : TestObjectMerger<IGqlpOutputField>
{
  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    : base(TypeKind.Output)
    => MergerObject = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpOutputField> MergerObject { get; }

  protected override IGqlpOutputField[] MakeFields(FieldInput[]? fields)
    => fields?.OutputFields() ?? [];
}
