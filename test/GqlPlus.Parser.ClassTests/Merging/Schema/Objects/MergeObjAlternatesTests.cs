using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeObjAlternatesTests(
  ITestOutputHelper outputHelper
) : TestDescriptionsMerger<IGqlpObjAlternate>
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

  internal CheckAlternatesMerger CheckAlternates { get; } = new();
  internal MergeObjAlternates MergerAlternate { get; } = new(outputHelper.ToLoggerFactory());
  internal override GroupsMerger<IGqlpObjAlternate> MergerGroups => MergerAlternate;

  protected override IGqlpObjAlternate MakeDescribed(string name, string description = "")
    => CheckAlternates.MakeAlternate(name, false, description);
}

internal sealed class CheckAlternatesMerger
  : ICheckAlternatesMerger
{
  public IGqlpObjAlternate MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new ObjAlternateAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}

internal interface ICheckAlternatesMerger
{
  IGqlpObjAlternate MakeAlternate(string input, bool withModifiers = false, string description = "");
}
