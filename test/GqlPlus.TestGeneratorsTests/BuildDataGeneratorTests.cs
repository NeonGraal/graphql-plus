using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class BuildDataGeneratorTests
{
  private static readonly string[] s_additionalFilesWithIncorrectOne = [
    "Sample/Files/File3.gql+",
    "Sample/Files/file2.graphql+",
    "Sample/Files/file1.txt",
    "Sample/git-details.txt"];
  private static readonly string[] s_additionalSubdirectoryFiles = [
    "Sample/Files/File3.gql",
    "Sample/More/file2.graphql+",
    "Sample/Files/Deeper/file1.gql+",
    "Sample/git-details.txt"];

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
