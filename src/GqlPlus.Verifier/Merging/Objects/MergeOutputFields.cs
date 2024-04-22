﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeOutputFields(
  ILoggerFactory logger,
  IMerge<ParameterAst> parameters
) : FieldsMerger<OutputFieldAst, OutputReferenceAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, OutputFieldAst> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyCanMerge(item => item.Parameters, parameters));

  protected override OutputFieldAst MergeGroup(IEnumerable<OutputFieldAst> group)
    => base.MergeGroup(group) with {
      Parameters = [.. group.ManyMerge(item => item.Parameters, parameters)],
    };
}
