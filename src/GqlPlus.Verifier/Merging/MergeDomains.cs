﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDomains<TMember>(
  ILoggerFactory logger,
  IMerge<TMember> members
) : AstTypeMerger<AstDomain, AstDomain<TMember>, string, TMember>(logger, members)
  where TMember : AstBase, IAstDomainItem
{
  protected override string ItemMatchName => "Domain~Parent";
  protected override string ItemMatchKey(AstDomain<TMember> item)
    => item.Domain.ToString() + item.Parent.Prefixed("~");

  internal override IEnumerable<TMember> GetItems(AstDomain<TMember> type)
    => type.Items;

  internal override AstDomain<TMember> SetItems(AstDomain<TMember> input, IEnumerable<TMember> items)
    => input with { Items = [.. items] };
}
