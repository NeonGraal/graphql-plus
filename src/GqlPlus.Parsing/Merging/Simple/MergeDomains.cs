using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomains<TMember>(
  ILoggerFactory logger,
  IMerge<TMember> members
) : AstTypeMerger<IGqlpDomain, IGqlpDomain<TMember>, string, TMember>(logger, members)
  where TMember : AstAbbreviated, IGqlpDomainItem
{
  protected override string ItemMatchName => "Domain~Parent";
  protected override string ItemMatchKey(IGqlpDomain<TMember> item)
    => item.DomainKind.ToString() + item.Parent.Prefixed("~");

  internal override IEnumerable<TMember> GetItems(IGqlpDomain<TMember> type)
    => type.Items;

  internal override IGqlpDomain<TMember> SetItems(IGqlpDomain<TMember> input, IEnumerable<TMember> items)
  {
    AstDomain<TMember> ast = (AstDomain<TMember>)input;
    return ast with { Members = [.. items] };
  }
}
