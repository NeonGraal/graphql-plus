//HintName: SampleData.gen.cs
// Generated from Sample
// Collected from Sample/git-details.txt

namespace GqlPlus;

public class SampleFilesData
  : TheoryData<string>
{
  public SampleFilesData()
  {
    Add("File3");
  }

  public const string From = "Sample/Files";
  public const string Collected = "Sample/git-details.txt";
}

public class SampleMoreData
  : TheoryData<string>
{
  public SampleMoreData()
  {
    Add("file2");
  }

  public const string From = "Sample/More";
  public const string Collected = "Sample/git-details.txt";
}
