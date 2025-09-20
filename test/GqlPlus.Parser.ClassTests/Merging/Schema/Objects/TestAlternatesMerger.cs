using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public abstract class TestAlternatesMerger
  : TestDescriptionsMerger<IGqlpObjAlternate>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameModifers_ReturnsGood(string input)
    => CanMerge_Good([
      CheckAlternates.MakeAlternate(input, true),
      CheckAlternates.MakeAlternate(input, true)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsErrors(string input)
    => CanMerge_Errors([
      CheckAlternates.MakeAlternate(input, true),
      MakeDescribed(input)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [CheckAlternates.MakeAlternate(input, true), CheckAlternates.MakeAlternate(input, true)],
      CheckAlternates.MakeAlternate(input, true));

  internal abstract ICheckAlternatesMerger<IGqlpObjAlternate> CheckAlternates { get; }
  internal abstract MergeAstAlternates MergerAlternate { get; }
  internal override GroupsMerger<IGqlpObjAlternate> MergerGroups => MergerAlternate;

  protected override IGqlpObjAlternate MakeDescribed(string name, string description = "")
    => CheckAlternates.MakeAlternate(name, false, description);
}

internal abstract class CheckAlternatesMerger<TObjAltAst>
  : ICheckAlternatesMerger<IGqlpObjAlternate>
  where TObjAltAst : ObjAlternateAst
{
  public abstract IGqlpObjAlternate MakeAlternate(string input, bool withModifiers = false, string description = "");
}

internal interface ICheckAlternatesMerger<TObjAlt>
  where TObjAlt : IGqlpObjAlternate
{
  TObjAlt MakeAlternate(string input, bool withModifiers = false, string description = "");
}
