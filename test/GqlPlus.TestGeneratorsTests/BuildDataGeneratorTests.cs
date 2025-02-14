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
    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate([]);

    return Verifier.Verify(driver);
  }

  [Fact]
  public Task IgnoresIncorrectAdditionalFiles()
  {
    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(s_additionalFilesWithIncorrectOne.AdditionalPaths());

    return Verifier.Verify(driver);
  }

  [Fact]
  public async Task SubDirectoryAdditionalFiles()
  {
    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(s_additionalSubdirectoryFiles.AdditionalPaths());

    await Verifier.Verify(driver);
  }
}
