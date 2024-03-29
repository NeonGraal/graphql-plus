﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeUnionsTests
  : TestTyped<AstType, UnionDeclAst, string, UnionMemberAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsValues_ReturnsExpected(string name, string[] members1, string[] members2)
  {
    var combined = members1.Concat(members2).Distinct().ToArray();

    Merge_Expected([
      new UnionDeclAst(AstNulls.At, name, members1.UnionMembers()),
      new UnionDeclAst(AstNulls.At, name, members2.UnionMembers())],
      new UnionDeclAst(AstNulls.At, name, combined.UnionMembers()));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameValues_ReturnsExpected(string name, string[] members)
    => Merge_Expected([
        new UnionDeclAst(AstNulls.At, name, members.UnionMembers()),
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers())],
        new UnionDeclAst(AstNulls.At, name, members.UnionMembers()));

  private readonly MergeUnions _merger = new(new MergeUnionMembers());

  internal override AstTypeMerger<AstType, UnionDeclAst, string, UnionMemberAst> MergerTyped => _merger;

  protected override UnionDeclAst MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, []);
  protected override string MakeParent(string parent)
    => parent;
}
