using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class BuildDataGeneratorTests
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  [Fact]
  public Task NoAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, []);

    return Verifier.Verify(driver, _settings);
  }

  private static readonly string[] s_additionalFilesWithIncorrectOne = [
    "a/Samples/Files/File3.gql+",
    "b/Samples/Files/file2.graphql+",
    "c/Samples/Files/file1.txt",
    "git-details.txt"];
  [Fact]
  public Task IgnoresIncorrectAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, s_additionalFilesWithIncorrectOne.AdditionalPaths(nameof(IgnoresIncorrectAdditionalFiles)));

    return Verifier.Verify(driver, _settings);
  }

  private static readonly string[] s_additionalSubdirectoryFiles = [
    "e/Samples/Files/File3.gql",
    "f/Samples/More/file2.graphql+",
    "g/Samples/Files/Deeper/file1.gql+",
    "git-details.txt"];
  [Fact]
  public Task SubDirectoryAdditionalFiles()
  {
    string source = "using GqlPlusTests;";

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, s_additionalSubdirectoryFiles.AdditionalPaths(nameof(SubDirectoryAdditionalFiles)));

    return Verifier.Verify(driver, _settings);
  }

  private static readonly string[] s_topDirs = ["Top", "Left", "Centre", "Right", "Bottom"];
  private static readonly string[] s_middleDirs = ["", "Red", "Orange", "Yellow", "Green", "Blue", "Purple"];
  private static readonly string[] s_bottomDirs = ["", "Valid", "InValid"];
  private static readonly string[] s_fileExtensions = ["gql", "graphql+"];
  [Fact]
  public Task ManyFiles()
  {
    string source = "using GqlPlusTests;";

    List<string> manyFiles = ["git-details.txt"];

    foreach (int index in Enumerable.Range(0, 500)) {
      string top = s_topDirs[index % 5];
      string middle = s_middleDirs[index % 7];
      string bottom = s_bottomDirs[index % 3];
      string extn = s_fileExtensions[index % 2];
      manyFiles.Add(Path.Combine("Samples", top, middle, bottom, $"File{index}.{extn}"));
    }

    GeneratorDriver driver = new BuildDataGenerator("GqlPlusTests")
      .Generate(source, manyFiles.AdditionalPaths(nameof(ManyFiles)));

    return Verifier.Verify(driver, _settings);
  }
}
