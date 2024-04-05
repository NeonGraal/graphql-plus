﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOutputFields(
  ILoggerFactory logger,
  IMerge<ParameterAst> parameters
) : FieldsMerger<OutputFieldAst, OutputReferenceAst>(logger)
{
  protected override bool CanMergeGroup(IGrouping<string, OutputFieldAst> group)
    => base.CanMergeGroup(group)
      && group.ManyCanMerge(item => item.Parameters, parameters);

  protected override OutputFieldAst MergeGroup(IEnumerable<OutputFieldAst> group)
    => base.MergeGroup(group) with {
      Parameters = [.. group.ManyMerge(item => item.Parameters, parameters)],
    };
}
