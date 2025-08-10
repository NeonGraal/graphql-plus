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
    => await Label_Inputs("Sample", await SchemaValidDataGroup(group), "+" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergeData))]
  public async Task Test_Merges(string model)
    => await ReplaceFileAsync("Merge", model, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectData))]
  public async Task Test_Objects(string model)
    => await ReplaceFileAsync("Object", model, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalData))]
  public async Task Test_Globals(string global)
    => await ReplaceFileAsync("Global", global, Sample_Input);

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

    await Label_Input("Spec", schema, ["Schema", "Specification"], sample);
  }

  protected abstract Task Label_Input(string label, string input, string[] dirs, string test, string section = "");

  protected virtual async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    string schema = inputs.Joined(Environment.NewLine);

    await Label_Input(label, schema, [label], test);
  }

  protected virtual Task Sample_Input(string input, string section, string test)
    => Label_Input("Sample", input, [section], test, section);
}
