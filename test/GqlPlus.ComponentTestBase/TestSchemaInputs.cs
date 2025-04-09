namespace GqlPlus;

public abstract class TestSchemaInputs
  : SampleChecks
{
  [Fact]
  public async Task Test_All()
    => await Label_Inputs("Sample", await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Test_Groups(string group)
    => await Label_Inputs("Sample", await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Test_Merges(string model)
    => await ReplaceFileAsync("Merges", model, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Test_Objects(string model)
    => await ReplaceFileAsync("Objects", model, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Test_Globals(string global)
    => await ReplaceFileAsync("Globals", global, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Test_Simple(string simple)
    => await ReplaceFileAsync("Simple", simple, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Test_Schema(string sample)
  {
    string schema = await ReadSchema(sample);

    await Label_Input("Schema", schema, ["Schema"], sample);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Test_Spec(string sample)
  {
    string schema = await ReadSchema(sample, "Specification");

    await Label_Input("Schema", schema, ["Schema", "Specification"], sample);
  }

  protected abstract Task Label_Input(string label, string input, string[] dirs, string test, string section = "");

  protected abstract Task Label_Inputs(string label, IEnumerable<string> inputs, string test);

  protected virtual Task Sample_Input(string input, string section, string test)
    => Label_Input("Sample", input, [section], test, section);
}
