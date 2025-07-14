﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Result;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class CanMergeSchemaTests(
  ILoggerFactory logger,
  ISchemaParseChecks checks,
  IMerge<IGqlpSchema> schemaMerger
) : TestSchemaResult(logger, checks)
{
  protected override Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    Check_CanMerge([result.Required()], test);

    return Task.CompletedTask;
  }

  protected override Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    IGqlpSchema[] schemas = [.. inputs.Select(input => checks.Parse(input, "Schema").Required())];

    Check_CanMerge(schemas, test);

    return Task.CompletedTask;
  }

  private void Check_CanMerge(IGqlpSchema[] schemas, string test)
  {
    IMessages result = schemaMerger.CanMerge(schemas);

    result.ShouldBeEmpty(test);
  }

  // Todo: Add error checking for invalid schemas
  protected override Task Result_Invalid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
    => Task.CompletedTask;
}
