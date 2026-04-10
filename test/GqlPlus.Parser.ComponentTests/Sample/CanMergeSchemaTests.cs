using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class CanMergeSchemaTests(
  ISchemaParseChecks checks,
  IMergerRepository mergers
) : TestSchemaResult(checks)
{
  private readonly IMerge<IAstSchema> _schemaMerger = mergers.MergerFor<IAstSchema>();

  protected override Task Result_Valid(IResult<IAstSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    Check_CanMerge([result.Required()], test);

    return Task.CompletedTask;
  }

  protected override Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    IAstSchema[] schemas = [.. inputs.Select(input => checks.Parse(input, "Schema").Required())];

    Check_CanMerge(schemas, test);

    return Task.CompletedTask;
  }

  private void Check_CanMerge(IAstSchema[] schemas, string test)
  {
    IMessages result = _schemaMerger.SkipIf(test == SchemaValidData.SpecDefinition).CanMerge(schemas);

    result.ShouldBeEmpty(test);
  }

  // Todo: Add error checking for invalid schemas
  protected override Task Result_Invalid(IResult<IAstSchema> result, string test, string label, string[] dirs, string section, string input = "")
    => Task.CompletedTask;
}
