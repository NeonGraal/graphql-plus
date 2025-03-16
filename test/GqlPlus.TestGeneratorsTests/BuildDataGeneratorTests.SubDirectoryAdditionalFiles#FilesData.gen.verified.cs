//HintName: FilesData.gen.cs
// Generated from Samples/Files
// Collected from SubDirectoryAdditionalFiles

namespace GqlPlusTests;

public class SamplesFilesData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "File3",
  ];

  public SamplesFilesData()
  {
    foreach (string s in Strings) Add(s);
  }

  public const string From = "Samples/Files/";
  public const string Collected = "SubDirectoryAdditionalFiles";
}

public class SamplesFilesDeeperData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "file1",
  ];

  public SamplesFilesDeeperData()
  {
    foreach (string s in Strings) Add(s);
  }

  public const string From = "Samples/Files/Deeper";
  public const string Collected = "SubDirectoryAdditionalFiles";
}
