using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeAllDomainsTests
  : TestDescriptionsMerger<IGqlpDomain>
{
  private readonly MergeAllDomains _merger;

  public MergeAllDomainsTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IGqlpDomain> result = Substitute.For<IMergeAll<IGqlpDomain>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IGqlpDomain>>());

    _merger = new(outputHelper.ToLoggerFactory(), [result]);
  }

  internal override GroupsMerger<IGqlpDomain> MergerGroups => _merger;

  protected override IGqlpDomain MakeDescribed(string name, string description = "")
    => new AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>(AstNulls.At, name, DomainKind.Boolean, [
        new DomainTrueFalseAst(AstNulls.At, "", false, true)
      ]);
}
