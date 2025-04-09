using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public abstract class TestSchemaAsts(
    ISchemaParseChecks checks
) : SampleChecks
{
  [Fact]
  public async Task Test_All()
    => await Test_Model(await SchemaValidDataAll(), "!ALL", "");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Test_Groups(string group)
    => await Test_Model(await SchemaValidDataGroup(group), "!" + group, "");

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Test_Merges(string model)
    => await ReplaceFileAsync("Merges", model, Test_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Test_Objects(string model)
    => await ReplaceFileAsync("Objects", model, Test_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Test_Globals(string global)
    => await ReplaceFileAsync("Globals", global, Test_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Test_Simple(string simple)
    => await ReplaceFileAsync("Simple", simple, Test_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Test_Schema(string sample)
  {
    IGqlpSchema ast = await checks.ParseSample("Schema", sample);

    await Test_Asts([ast], sample, "Schema");
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Test_Spec(string sample)
  {
    IGqlpSchema ast = await checks.ParseSample("Spec", sample, "Specification");

    await Test_Asts([ast], sample, "Spec", ["Schema", "Specification"]);
  }

  private async Task Test_Model(string input, string testDirectory, string test)
  {
    IGqlpSchema asts = checks.ParseInput(input, "Sample");

    await Test_Asts([asts], test, "Sample", testDirectory, input);
  }

  private async Task Test_Model(IEnumerable<string> inputs, string test, string testDirectory)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => checks.ParseInput(input, "Sample"));

    await Test_Asts(asts, test, "Sample", testDirectory);
  }

  protected virtual Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[]? dirs = null)
    => Test_Asts(asts, test, label, dirs ?? [label], "");

  private Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string testDirectory, string input = "")
    => Test_Asts(asts, test, label, [label], testDirectory, input);

  protected abstract Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string testDirectory, string input = "");
}
