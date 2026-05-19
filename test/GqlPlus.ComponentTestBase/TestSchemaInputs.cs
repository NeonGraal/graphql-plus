namespace GqlPlus;

public abstract class TestSchemaInputs
  : SampleChecks
{
  [Theory]
  [ClassData(typeof(SamplesGraphQlGraphqlData))]
  public Task Test_GraphQL(string sample)
    => Schema_Input("GraphQl", sample);

  [Fact]
  public async Task Test_SchemaAll()
    => await Label_Inputs("Schema", await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Test_SchemaGroups(string group)
    => await Label_Inputs("Schema", await SchemaValidDataGroup(group), "+" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Test_SchemaMerges(string model)
    => await ReplaceFileAsync("Merges", model, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Test_SchemaObjects(string model)
    => await ReplaceFileAsync("Objects", model, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Test_SchemaGlobals(string global)
    => await ReplaceFileAsync("Globals", global, Sample_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Test_SchemaSimple(string simple)
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
  public Task Test_Spec(string sample)
    => Schema_Input("Spec", sample, "Specification");

  [Theory]
  [ClassData(typeof(SamplesSpecificationIntrospectionData))]
  public Task Test_SpecIntrospection(string sample)
    => Schema_Input("Spec", sample, "Specification", "Introspection");

  [Theory]
  [ClassData(typeof(SamplesStarWarsData))]
  public Task Test_StarWars(string sample)
    => Schema_Input("StarWars", sample);

  private async Task Schema_Input(string label, string file, params string[] dirs)
  {
    if (dirs.Length == 0) {
      dirs = [label];
    }

    string section = dirs.Length > 1 ? dirs.Last() : "";

    string schema = await ReadFile(file, "graphql+", dirs);

    await Test_Input(label, schema, dirs, file, section);
  }

  [Theory]
  [ClassData(typeof(SamplesSpecificationRequestData))]
  public async Task Test_SpecRequest(string sample)
  {
    string spec = await ReadSpecification(sample, "Request");

    await Test_Input("Spec", spec, ["Specification", "Request"], sample, "Request");
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
