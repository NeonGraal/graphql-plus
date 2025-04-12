using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace GqlPlus.Sample;

public class GqlModelSchemaTests
  : TestSchemaInputs
{

  [Fact]
  public Task NoAdditionalFiles()
  {
    GeneratorDriver driver = new GqlModelGenerator()
      .Generate([]);

    return Verify(driver);
  }

  protected override async Task Label_Input(string label, string input, string[] dirs, [NotNull] string test, string section = "")
  {
    GqlModelConfigOptionsProvider options = new();

    string testFile = test.Replace("!", "-", StringComparison.Ordinal) + ".graphql+";

    GeneratorDriver driver = new GqlModelGenerator()
      .Generate(testFile.AdditionalString(input), options);

    await Verify(driver, CustomSettings(label, "GqlModel", test, section, scrubEmptyLines: false));
  }
}
