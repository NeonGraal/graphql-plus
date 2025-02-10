namespace GqlPlus;

public class BuildDataGeneratorTests
{
  [Fact]
  public Task NoAdditionalFiles()
  {
    string source = "using GqlPlus;";

    // Pass the source code to our helper and snapshot test the output
    return TestGeneratorsHelper.Verify(source);
  }

  [Fact]
  public Task IgnoresIncorrectAdditionalFiles()
  {
    string source = "using GqlPlus;";

    // Pass the source code to our helper and snapshot test the output
    return TestGeneratorsHelper.Verify(source, "Sample/Files/File3.gql+", "Sample/Files/file2.graphql+", "Sample/Files/file1.txt", "Sample/git-details.txt");
  }

  [Fact]
  public Task SubDirectoryAdditionalFiles()
  {
    string source = "using GqlPlus;";

    // Pass the source code to our helper and snapshot test the output
    return TestGeneratorsHelper.Verify(source, "Sample/Files/File3.gql", "Sample/More/file2.graphql+", "Sample/Files/Deeper/file1.gql+", "Sample/git-details.txt");
  }
}
