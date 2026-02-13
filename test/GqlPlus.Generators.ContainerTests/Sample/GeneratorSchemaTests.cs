using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace GqlPlus.Sample;

public class GeneratorSchemaTests
  : TestSchemaInputs
{

  [Fact]
  public Task NoAdditionalFiles()
  {
    GeneratorDriver driver = new GqlpGenerator()
      .Generate("");

    return Verify(driver);
  }

  protected override async Task Label_Input(string label, string input, string[] dirs, [NotNull] string test, string section = "")
  {
    GqlModelConfigOptionsProvider options = new();

    string testFile = test.Replace("!", "-", StringComparison.Ordinal) + ".graphql+";

    GeneratorDriver driver = new GqlpGenerator()
      .Generate(GeneratorSource, testFile.AdditionalString(input), [typeof(GqlpGeneratorType)], options, true);

    await driver.AttachAndVerify(CustomSettings(label, "Generator", test, section, scrubEmptyLines: false));
  }

  private const string GeneratorSource = @"
    namespace GqlPlus.GeneratorTests;
    [GqlpGenerator(GqlpGeneratorType.Static)] 
    [GqlpGenerator(GqlpGeneratorType.Interface)] 
    public interface IGqlpModelImplementationBase {}
    [GqlpGenerator(GqlpGeneratorType.Enum)] 
    [GqlpGenerator(GqlpGeneratorType.Implementation)] 
    public class GqlpModelImplementationBase {}
";
}

