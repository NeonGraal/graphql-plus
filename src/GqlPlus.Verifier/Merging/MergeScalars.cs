﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars<TMember>(
  ILoggerFactory logger,
  IMerge<TMember> members
) : AstTypeMerger<AstScalar, AstScalar<TMember>, string, TMember>(logger, members)
  where TMember : AstBase, IAstScalarItem
{
  protected override string ItemMatchName => "Domain~Parent";
  protected override string ItemMatchKey(AstScalar<TMember> item)
    => item.Domain.ToString() + item.Parent.Prefixed("~");

  internal override IEnumerable<TMember> GetItems(AstScalar<TMember> type)
    => type.Items;

  internal override AstScalar<TMember> SetItems(AstScalar<TMember> input, IEnumerable<TMember> items)
    => input with { Items = [.. items] };
}
