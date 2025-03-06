using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Schema.Simple;

public class MergeDomainAstEnumsTests
  : TestDomainAsts<IGqlpDomainMember, string>
{
  internal override IDomainMerger<IGqlpDomainMember> Merger { get; }
  internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainMember>, string, IGqlpDomainMember> MergerTyped { get; }

  public MergeDomainAstEnumsTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainMemberAst, IGqlpDomainMember> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    MergerTyped = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainMember> MakeDomain(string name, string[]? aliases = null, string description = "", string? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainMember>? items = null)
    => new AstDomain<DomainMemberAst, IGqlpDomainMember>(AstNulls.At, name, description, kind ?? DomainKind.Enum) {
      Aliases = aliases ?? [],
      Parent = parent,
      Members = items?.ArrayOf<DomainMemberAst>() ?? [],
    };

  protected override IGqlpDomainMember[] MakeItems(string input)
    => new[] { input }.DomainMembers();
}
