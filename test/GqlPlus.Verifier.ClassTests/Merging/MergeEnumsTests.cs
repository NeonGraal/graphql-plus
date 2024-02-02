using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeEnumsTests
  : TestTyped<AstType, EnumDeclAst, string>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsValuesCantMerge_ReturnsFalse(string name, string[] values)
  {
    _enumMembers.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      new EnumDeclAst(AstNulls.At, name) with { Members = values.EnumMembers() },
      new EnumDeclAst(AstNulls.At, name)],
      values.Length < 2);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsValues_ReturnsExpected(string name, string[] values1, string[] values2)
  {
    var combined = values1.EnumMembers().Concat(values2.EnumMembers()).ToArray();

    Merge_Expected([
      new EnumDeclAst(AstNulls.At, name) with { Members = values1.EnumMembers() },
      new EnumDeclAst(AstNulls.At, name) with { Members = values2.EnumMembers() }],
      new EnumDeclAst(AstNulls.At, name) with { Members = combined });
  }

  private readonly IMerge<EnumMemberAst> _enumMembers;
  private readonly MergeEnums _merger;

  public MergeEnumsTests()
  {
    _enumMembers = Merger<EnumMemberAst>();

    _merger = new(_enumMembers);
  }

  internal override TypedMerger<AstType, EnumDeclAst, string> MergerTyped => _merger;

  protected override EnumDeclAst MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override string MakeParent(string parent)
    => parent;
}
