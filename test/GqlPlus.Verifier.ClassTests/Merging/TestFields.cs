using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestFields<TField, TReference>
  : TestDescriptions<TField>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected abstract FieldsMerger<TField, TReference> MergerField { get; }
  protected override DescribedsMerger<TField> MergerDescribed => MergerField;

  protected abstract TField MakeField(string name, string type, string description = "");
  protected override TField MakeDescribed(string name, string description = "")
    => MakeField(name, name, description);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneType_ReturnsTrue(string name, string type, string description)
  {
    var items = new[] { MakeField(name, type, description), MakeField(name, type, description) };

    var result = MergerField.CanMerge(items);

    result.Should().BeTrue();
  }
}
