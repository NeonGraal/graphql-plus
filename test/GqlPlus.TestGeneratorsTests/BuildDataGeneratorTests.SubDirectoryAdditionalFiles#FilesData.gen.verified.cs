//HintName: FilesData.gen.cs
// Generated from Sample/Files
// Collected from Sample/git-details.txt

namespace GqlPlusTests;

public class FilesDeeperData
  : TheoryData<string>
{
  public FilesDeeperData()
  {
    Add("file1");
  }

  public const string From = "Sample/Files/Deeper";
  public const string Collected = "Sample/git-details.txt";
}
