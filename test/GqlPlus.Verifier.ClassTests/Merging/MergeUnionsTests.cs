using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeUnionsTests
  : TestTyped<AstType, UnionDeclAst, string, UnionMemberAst>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsFalse(string name, string[] members)
  {
    _unionMembers.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
        new UnionDeclAst(AstNulls.At, name, members.UnionMembers()),
      new UnionDeclAst(AstNulls.At, name, [])],
        members is null || members.Length < 2);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsValues_ReturnsExpected(string name, string[] members1, string[] members2)
  {
    var combined = members1.Concat(members2).Distinct().ToArray();

    Merge_Expected([
      new UnionDeclAst(AstNulls.At, name, members1.UnionMembers()),
      new UnionDeclAst(AstNulls.At, name, members2.UnionMembers())],
      new UnionDeclAst(AstNulls.At, name, combined.UnionMembers()));
  }

  private readonly IMerge<UnionMemberAst> _unionMembers;
  private readonly MergeUnions _merger;

  public MergeUnionsTests()
  {
    _unionMembers = Merger<UnionMemberAst>();

    _merger = new(_unionMembers);
  }

  internal override AstTypeMerger<AstType, UnionDeclAst, string, UnionMemberAst> MergerTyped => _merger;

  protected override UnionDeclAst MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, []);
  protected override string MakeParent(string parent)
    => parent;
}
