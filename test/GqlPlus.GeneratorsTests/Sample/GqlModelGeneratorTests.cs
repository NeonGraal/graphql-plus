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
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Generate_Schema(string sample)
    => await Generate_ModelFor(await ReadSchema(sample), sample, "Schema");

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Generate_Spec(string sample)
    => await Generate_ModelFor(await ReadSchema(sample, "Specification"), sample, "Spec");

  private async Task Generate_Model(IEnumerable<string> inputs, string test)
    => await Generate_ModelFor(inputs.Joined(Environment.NewLine), test, "Sample");

  private async Task Generate_ModelFor(string input, string test, string label)
  {
    GqlModelConfigOptionsProvider options = new();

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate((test + ".graphql+").AdditionalString(input), options);

    await Verify(driver, CustomSettings(label, "Model", test, false));
  }
}
