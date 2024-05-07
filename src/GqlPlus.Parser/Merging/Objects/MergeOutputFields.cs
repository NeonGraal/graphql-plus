﻿using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputFields(
  ILoggerFactory logger,
  IMerge<ParameterAst> parameters
) : AstObjectFieldsMerger<OutputFieldAst, OutputBaseAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, OutputFieldAst> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyCanMerge(item => item.Parameters, parameters));

  protected override OutputFieldAst MergeGroup(IEnumerable<OutputFieldAst> group)
    => base.MergeGroup(group) with {
      Parameters = [.. group.ManyMerge(item => item.Parameters, parameters)],
    };
}
