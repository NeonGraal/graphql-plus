using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeAllDomainsTypeTests
  : TestAbbreviatedMerger<IAstType>
{

  private readonly MergeAllDomains _merger;

  public MergeAllDomainsTypeTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IAstDomain> result = Substitute.For<IMergeAll<IAstDomain>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IAstDomain>>());

    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.AllMergersFor<IAstDomain>().Returns([result]);
    _merger = new(mergers);
  }

  protected override IMerge<IAstType> MergerBase => _merger;

  public override void CanMerge_NoAsts_ReturnsErrors()
    => CanMerge_Good([]);

  protected override IAstType MakeAst(string input)
    => new AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse>(AstNulls.At, input, DomainKind.Boolean, [
        new DomainTrueFalseAst(AstNulls.At, "", false, true)
      ]);
}
