//HintName: FilesData.gen.cs
// Generated from Samples/Files
// Collected from SubDirectoryAdditionalFiles

namespace GqlPlusTests;

public class SamplesFilesGqlData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "File3",
  ];

  public SamplesFilesGqlData()
    : base(Strings)
  { }

  public const string From = "Samples/Files/Gql";
  public const string Collected = "SubDirectoryAdditionalFiles";
}

public class SamplesFilesDeeperGqlData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "file1",
  ];

  public SamplesFilesDeeperGqlData()
    : base(Strings)
  { }

  public const string From = "Samples/Files/DeeperGql";
  public const string Collected = "SubDirectoryAdditionalFiles";
}
