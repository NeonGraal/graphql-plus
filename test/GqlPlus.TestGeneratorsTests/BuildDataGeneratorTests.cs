using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class BuildDataGeneratorTests
{
  private static readonly string[] s_additionalFilesWithIncorrectOne = [
    "a/Samples/Files/File3.gql+",
    "b/Samples/Files/file2.graphql+",
    "c/Samples/Files/file1.txt",
    "git-details.txt"];
  private static readonly string[] s_additionalSubdirectoryFiles = [
    "e/Samples/Files/File3.gql",
    "f/Samples/More/file2.graphql+",
    "g/Samples/Files/Deeper/file1.gql+",
    "git-details.txt"];

  [Fact]
  public Task NoAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, []);

    return Verifier.Verify(driver);
  }

  [Fact]
  public Task IgnoresIncorrectAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, s_additionalFilesWithIncorrectOne.AdditionalPaths());

    return Verifier.Verify(driver);
  }

  [Fact]
  public Task SubDirectoryAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, s_additionalSubdirectoryFiles.AdditionalPaths());

    return Verifier.Verify(driver);
  }
}
