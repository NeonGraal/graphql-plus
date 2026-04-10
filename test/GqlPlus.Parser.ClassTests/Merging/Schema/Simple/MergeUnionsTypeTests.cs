using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeUnionsTypeTests
  : TestAbbreviatedMerger<IAstType>
{

  private readonly MergeUnions _merger;

  public MergeUnionsTypeTests(ITestOutputHelper outputHelper)
  {
    IMerge<IGqlpUnionMember> result = Substitute.For<IMerge<IGqlpUnionMember>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IGqlpUnionMember>>());

    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpUnionMember>().Returns(result);
    _merger = new(mergers);
  }

  protected override IMerge<IAstType> MergerBase => _merger;

  public override void CanMerge_NoAsts_ReturnsErrors()
    => CanMerge_Good([]);

  protected override IAstType MakeAst(string input)
    => new UnionDeclAst(AstNulls.At, input, "", []);
}
