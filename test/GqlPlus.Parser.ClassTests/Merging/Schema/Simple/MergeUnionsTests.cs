using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeUnionsTests
  : TestSimpleMerger<IAstType, IAstUnion, IAstUnionMember, string>
{
  private readonly MergeUnions _merger;

  public MergeUnionsTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstUnionMember>().Returns(MergeItems);
    _merger = new(mergers);
  }

  internal override AstSimpleMerger<IAstType, IAstUnion, IAstUnionMember> MergerSimple => _merger;

  protected override IAstUnionMember[] MakeItems(string input)
    => new[] { input }.UnionMembers();
  protected override IAstUnion MakeSimple(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, IEnumerable<IAstUnionMember>? items = null)
    => new UnionDeclAst(AstNulls.At, name, description, [.. items ?? []]) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
}
