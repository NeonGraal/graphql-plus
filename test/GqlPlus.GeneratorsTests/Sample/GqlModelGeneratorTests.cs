using Microsoft.CodeAnalysis;
using Xunit.DependencyInjection;

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

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Generate_Schema(string sample)
  {
    string schema = await ReadSchema(sample);

    GqlModelConfigOptionsProvider options = new();

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate((sample + ".graphql+").AdditionalString(schema), options);

    await Verify(driver, CustomSettings("Schema", "Model", sample, false));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Generate_Spec(string sample)
  {
    string schema = await ReadSchema(sample, "Specification");

    GqlModelConfigOptionsProvider options = new();

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate((sample + ".graphql+").AdditionalString(schema), options);

    await Verify(driver, CustomSettings("Spec", "Model", sample, false));
  }
}
