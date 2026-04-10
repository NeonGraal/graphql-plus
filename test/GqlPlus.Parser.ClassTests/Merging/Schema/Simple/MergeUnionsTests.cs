using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeUnionsTests
  : TestSimpleMerger<IAstType, IGqlpUnion, IGqlpUnionMember, string>
{
  private readonly MergeUnions _merger;

  public MergeUnionsTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpUnionMember>().Returns(MergeItems);
    _merger = new(mergers);
  }

  internal override AstSimpleMerger<IAstType, IGqlpUnion, IGqlpUnionMember> MergerSimple => _merger;

  protected override IGqlpUnionMember[] MakeItems(string input)
    => new[] { input }.UnionMembers();
  protected override IGqlpUnion MakeSimple(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, IEnumerable<IGqlpUnionMember>? items = null)
    => new UnionDeclAst(AstNulls.At, name, description, [.. items ?? []]) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
}
