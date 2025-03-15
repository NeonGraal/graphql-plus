//HintName: MoreData.gen.cs
// Generated from Samples/More
// Collected from SubDirectoryAdditionalFiles

namespace GqlPlusTests;

public class SamplesMoreData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "file2",
  ];

  public SamplesMoreData()
  {
    foreach (string s in Strings) Add(s);
  }

  public const string From = "Samples/More/";
  public const string Collected = "SubDirectoryAdditionalFiles";
}
