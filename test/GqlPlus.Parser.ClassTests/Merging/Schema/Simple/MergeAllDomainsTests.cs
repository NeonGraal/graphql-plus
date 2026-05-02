using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeAllDomainsTests
  : TestDescriptionsMerger<IAstDomain>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameNameDifferentTypes_ReturnsErrors(string input)
    => CanMerge_Errors([MakeAst(input),
      new AstDomain<DomainRegexAst, IAstDomainRegex>(AstNulls.At, input, DomainKind.String, [])]);

  private readonly MergeAllDomains _merger;

  public MergeAllDomainsTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IAstDomain> result = Substitute.For<IMergeAll<IAstDomain>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IAstDomain>>());

    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.AllMergersForReturns(result);
    _merger = new(mergers);
  }

  internal override GroupsMerger<IAstDomain> MergerGroups => _merger;

  protected override IAstDomain MakeDescribed(string name, string description = "")
    => new AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse>(AstNulls.At, name, DomainKind.Boolean, [
        new DomainTrueFalseAst(AstNulls.At, "", false, true)
      ]);
}
