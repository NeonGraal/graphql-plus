using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace GqlPlus.Sample;

public class GqlpGeneratorSchemaTests
  : TestSchemaInputs
{

  [Fact]
  public Task NoAdditionalFiles()
  {
    GeneratorDriver driver = new GqlpGenerator()
      .Generate("", []);

    return Verify(driver);
  }

  protected override async Task Label_Input(string label, string input, string[] dirs, [NotNull] string test, string section = "")
  {
    GqlModelConfigOptionsProvider options = new();

    string testFile = test.Replace("!", "-", StringComparison.Ordinal) + ".graphql+";

    GeneratorDriver driver = new GqlpGenerator()
      .Generate(GqlpGeneratorSource, testFile.AdditionalString(input), options);

    await Verify(driver, CustomSettings(label, "GqlpGenerator", test, section, scrubEmptyLines: false));
  }

  private const string GqlpGeneratorSource = @"
    namespace GqlPlus.GqlpGeneratorSchemaTests;
    [GqlpGenerator(GqlpGeneratorType.Static)] 
    [GqlpGenerator(GqlpGeneratorType.Interface)] 
    public interface IGqlModelImplementationBase {}
    [GqlpGenerator(GqlpGeneratorType.Enum)] 
    [GqlpGenerator(GqlpGeneratorType.Implementation)] 
    public class GqlModelImplementationBase {}
";
}
