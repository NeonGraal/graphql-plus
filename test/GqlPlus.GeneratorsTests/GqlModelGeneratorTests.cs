using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class GqlModelGeneratorTests
{

  [Fact]
  public Task NoAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate(source, []);

    return Verifier.Verify(driver);
  }
}
