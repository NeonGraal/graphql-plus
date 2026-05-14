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
    : base(Strings)
  { }

  public const string From = "Samples/More/";
  public const string Collected = "SubDirectoryAdditionalFiles";
}
