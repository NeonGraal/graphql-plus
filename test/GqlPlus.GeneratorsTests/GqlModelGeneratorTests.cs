using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class GqlModelGeneratorTests : SampleChecks
{

  [Fact]
  public Task NoAdditionalFiles()
  {
    GeneratorDriver driver = new GqlModelGenerator()
      .Generate([]);

    return Verifier.Verify(driver);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task ModelSchema(string sample)
  {
    string schema = await ReadSchema(sample);

    GqlModelConfigOptionsProvider options = new();

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate((sample + ".graphql+").AdditionalString(schema), options);

    await Verifier.Verify(driver, CustomSettings("Schema", "Model", sample));
  }
}
