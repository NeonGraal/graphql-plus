using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeUnionsTypeTests
  : TestAbbreviatedMerger<IGqlpType>
{

  private readonly MergeUnions _merger;

  public MergeUnionsTypeTests(ITestOutputHelper outputHelper)
  {
    IMerge<IGqlpUnionMember> result = Substitute.For<IMerge<IGqlpUnionMember>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IGqlpUnionMember>>());

    _merger = new(outputHelper.ToLoggerFactory(), result);
  }

  protected override IMerge<IGqlpType> MergerBase => _merger;

  public override void CanMerge_NoAsts_ReturnsErrors()
    => CanMerge_Good([]);

  protected override IGqlpType MakeAst(string input)
    => new UnionDeclAst(AstNulls.At, input, "", []);
}
