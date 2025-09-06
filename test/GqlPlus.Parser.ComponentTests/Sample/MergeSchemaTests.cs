using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Result;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class MergeSchemaTests(
  ILoggerFactory logger,
  ISchemaParseChecks checks,
  IMerge<IGqlpSchema> schemaMerger
) : TestSchemaResult(logger, checks)
{
  protected override Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
    => Check_Merges([result.Required()], test, label, section);

  protected override async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    IGqlpSchema[] schemas = [.. inputs.Select(input => checks.Parse(input, "Schema").Required())];

    await Check_Merges(schemas, test, label, "");
  }

  private async Task Check_Merges(IGqlpSchema[] schemas, string test, string label, string section)
  {
    IEnumerable<IGqlpSchema> result = schemaMerger.SkipIf(test == SchemaValidData.SpecDefinition).Merge(schemas);

    await Verify(result.Select(s => s.Show()), CustomSettings(label, "Merges", test, section));
  }

  // Todo: Add error checking for invalid schemas
  protected override Task Result_Invalid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
    => Task.CompletedTask;
}
