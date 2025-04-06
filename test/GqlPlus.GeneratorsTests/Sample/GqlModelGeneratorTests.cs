using Microsoft.CodeAnalysis;

namespace GqlPlus.Sample;

public class GqlModelGeneratorTests : SampleChecks
{

  [Fact]
  public Task NoAdditionalFiles()
  {
    GeneratorDriver driver = new GqlModelGenerator()
      .Generate([]);

    return Verify(driver);
  }

  [Fact]
  public async Task Lines_All()
    => await Generate_Model(await SchemaValidDataAll(), "-ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Lines_Groups(string group)
    => await Generate_Model(await SchemaValidDataGroup(group), "-" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Lines_Merges(string model)
    => await ReplaceFileAsync("Merges", model, Generate_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Lines_Objects(string model)
    => await ReplaceFileAsync("Objects", model, Generate_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Lines_Globals(string global)
    => await ReplaceFileAsync("Globals", global, Generate_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Lines_Simple(string simple)
    => await ReplaceFileAsync("Simple", simple, Generate_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Generate_Schema(string sample)
    => await Generate_ModelFor(await ReadSchema(sample), sample, "Schema");

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Generate_Spec(string sample)
    => await Generate_ModelFor(await ReadSchema(sample, "Specification"), sample, "Spec");

  private async Task Generate_ModelFor(string input, string test, string label)
  {
    GqlModelConfigOptionsProvider options = new();

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate((test + ".graphql+").AdditionalString(input), options);

    await Verify(driver, CustomSettings(label, "Model", test, false));
  }

  private async Task Generate_Model(string input, string testDirectory, string test)
    => await Generate_ModelFor(input, test, "Sample");

  private async Task Generate_Model(IEnumerable<string> inputs, string test)
    => await Generate_Model(inputs.Joined(Environment.NewLine), "", test);
}
