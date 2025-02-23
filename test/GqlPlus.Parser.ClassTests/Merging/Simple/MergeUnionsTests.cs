using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeUnionsTests(
  ITestOutputHelper outputHelper
) : TestTyped<IGqlpType, IGqlpUnion, string, IGqlpUnionItem>
{
  [Theory, RepeatData]
  public void Merge_TwoAstsValues_ReturnsExpected(string name, string[] members1, string[] members2)
  {
    string[] combined = members1.Concat(members2).Distinct().ToArray();

    Merge_Expected([
      new UnionDeclAst(AstNulls.At, name, members1.UnionMembers()),
      new UnionDeclAst(AstNulls.At, name, members2.UnionMembers())],
      new UnionDeclAst(AstNulls.At, name, combined.UnionMembers()));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsSameValues_ReturnsExpected(string name, string[] members)
    => Merge_Expected([
        new UnionDeclAst(AstNulls.At, name, members.UnionMembers()),
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers())],
        new UnionDeclAst(AstNulls.At, name, members.UnionMembers()));

  private readonly MergeUnions _merger = new(outputHelper.ToLoggerFactory(), new MergeUnionMembers());

  internal override AstTypeMerger<IGqlpType, IGqlpUnion, string, IGqlpUnionItem> MergerTyped => _merger;

  protected override IGqlpUnion MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new UnionDeclAst(AstNulls.At, name, description, []) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
  protected override string MakeParent(string parent)
    => parent;
}
