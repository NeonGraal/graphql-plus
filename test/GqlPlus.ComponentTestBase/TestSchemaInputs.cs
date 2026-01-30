namespace GqlPlus;

public abstract class TestSchemaInputs
  : SampleChecks
{

  [Fact]
  public async Task Test_All()
    => await Label_Inputs("Schema", await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Test_Groups(string group)
    => await Label_Inputs("Schema", await SchemaValidDataGroup(group), "+" + group);

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

    await Test_Input("Schema", schema, ["Schema"], sample);
  }

  [Theory]
  [ClassData(typeof(SamplesSpecificationData))]
  public async Task Test_Spec(string sample)
  {
    string spec = await ReadSpecification(sample);

    await Test_Input("Spec", spec, ["Specification"], sample);
  }

  [Theory]
  [ClassData(typeof(SamplesSpecificationIntrospectionData))]
  public async Task Test_Introspection(string sample)
  {
    string spec = await ReadSpecification(sample, "Introspection");

    await Test_Input("Spec", spec, ["Specification", "Introspection"], sample, "Introspection");
  }

  protected abstract Task Label_Input(string label, string input, string[] dirs, string test, string section = "");

  protected virtual async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    string schema = inputs.Joined(Environment.NewLine);

    await Test_Input(label, schema, [label], test);
  }

  protected virtual Task Sample_Input(string input, string section, string test)
    => Test_Input("Schema", input, [section], test, section);

  protected async Task Test_Input(string label, string input, string[] dirs, string test, string section = "")
  {
    TestContext.Current.AddAttachment("Input " + test, input);

    await Label_Input(label, input, dirs, test, section);
  }
}
