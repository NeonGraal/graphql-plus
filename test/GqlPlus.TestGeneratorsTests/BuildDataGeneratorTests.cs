using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class BuildDataGeneratorTests
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  [Fact]
  public Task NoAdditionalFiles()
  {
    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate([]);

    return Verifier.Verify(driver, _settings);
  }

  private static readonly string[] s_additionalFilesWithIncorrectOne = [
    "a/Samples/Files/File3.gql+",
    "b/Samples/Files/file2.graphql+",
    "c/Samples/Files/file1.txt",
    "git-details.txt"];
  [Fact]
  public async Task IgnoresIncorrectAdditionalFiles()
  {
    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(s_additionalFilesWithIncorrectOne.AdditionalPaths(nameof(IgnoresIncorrectAdditionalFiles)));

    await Verifier.Verify(driver, _settings);
  }

  private static readonly string[] s_additionalSubdirectoryFiles = [
    "e/Samples/Files/File3.gql",
    "f/Samples/More/file2.graphql+",
    "g/Samples/Files/Deeper/file1.gql+",
    "git-details.txt"];
  [Fact]
  public async Task SubDirectoryAdditionalFiles()
  {
    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(s_additionalSubdirectoryFiles.AdditionalPaths(nameof(SubDirectoryAdditionalFiles)));

    await Verifier.Verify(driver, _settings);
  }

  private static readonly string[] s_topDirs = ["Top", "Left", "Centre", "Right", "Bottom"];
  private static readonly string[] s_middleDirs = ["", "Red", "Orange", "Yellow", "Green", "Blue", "Purple"];
  private static readonly string[] s_bottomDirs = ["", "Valid", "InValid"];
  private static readonly string[] s_fileExtensions = ["gql", "graphql+"];
  [Fact]
  public async Task ManyFiles()
  {
    List<string> manyFiles = ["git-details.txt"];

    foreach (int index in Enumerable.Range(0, 500)) {
      string top = s_topDirs[index % 5];
      string middle = s_middleDirs[index % 7];
      string bottom = s_bottomDirs[index % 3];
      string extn = s_fileExtensions[index % 2];
      manyFiles.Add(Path.Combine("Samples", top, middle, bottom, $"File{index}.{extn}"));
    }

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(manyFiles.AdditionalPaths(nameof(ManyFiles)));

    await Verifier.Verify(driver, _settings);
  }
}
