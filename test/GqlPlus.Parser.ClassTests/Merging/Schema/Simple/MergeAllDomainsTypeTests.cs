using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeAllDomainsTypeTests
  : TestAbbreviatedMerger<IGqlpType>
{

  private readonly MergeAllDomains _merger;

  public MergeAllDomainsTypeTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IGqlpDomain> result = Substitute.For<IMergeAll<IGqlpDomain>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IGqlpDomain>>());

    _merger = new(outputHelper.ToLoggerFactory(), [result]);
  }

  protected override IMerge<IGqlpType> MergerBase => _merger;

  public override void CanMerge_NoAsts_ReturnsErrors()
    => CanMerge_Good([]);

  protected override IGqlpType MakeAst(string input)
    => new AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>(AstNulls.At, input, DomainKind.Boolean, [
        new DomainTrueFalseAst(AstNulls.At, "", false, true)
      ]);
}
