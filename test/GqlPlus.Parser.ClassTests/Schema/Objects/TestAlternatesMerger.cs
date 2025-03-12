using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Schema.Objects;

public abstract class TestAlternatesMerger<TObjAlt, TObjBase>
  : TestDescriptionsMerger<TObjAlt>
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
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

  internal abstract ICheckAlternatesMerger<TObjAlt> CheckAlternates { get; }
  internal abstract AstAlternatesMerger<TObjAlt> MergerAlternate { get; }
  internal override GroupsMerger<TObjAlt> MergerGroups => MergerAlternate;

  protected override TObjAlt MakeDescribed(string name, string description = "")
    => CheckAlternates.MakeAlternate(name, false, description);
}

internal abstract class CheckAlternatesMerger<TObjAlt, TObjAltAst, TObjBase>
  : ICheckAlternatesMerger<TObjAlt>
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase
{
  public abstract TObjAlt MakeAlternate(string input, bool withModifiers = false, string description = "");
}

internal interface ICheckAlternatesMerger<TObjAlt>
  where TObjAlt : IGqlpObjAlternate
{
  TObjAlt MakeAlternate(string input, bool withModifiers = false, string description = "");
}
