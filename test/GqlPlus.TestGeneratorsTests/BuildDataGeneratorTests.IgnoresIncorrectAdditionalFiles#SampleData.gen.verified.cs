//HintName: SampleData.gen.cs
// Generated from Sample
// Collected from Sample/git-details.txt

namespace GqlPlusTests;

public class SampleFilesData
  : TheoryData<string>
{
  public SampleFilesData()
  {
    Add("file2");
    Add("File3");
  }

  public const string From = "Sample/Files";
  public const string Collected = "Sample/git-details.txt";
}
