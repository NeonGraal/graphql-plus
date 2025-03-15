//HintName: FilesData.gen.cs
// Generated from Samples/Files
// Collected from SubDirectoryAdditionalFiles

namespace GqlPlusTests;

public class SamplesFilesData
  : TheoryData<string>
{
  public SamplesFilesData()
  {
    Add("File3");
  }

  public const string From = "Samples/Files/";
  public const string Collected = "SubDirectoryAdditionalFiles";
}

public class SamplesFilesDeeperData
  : TheoryData<string>
{
  public SamplesFilesDeeperData()
  {
    Add("file1");
  }

  public const string From = "Samples/Files/Deeper";
  public const string Collected = "SubDirectoryAdditionalFiles";
}
