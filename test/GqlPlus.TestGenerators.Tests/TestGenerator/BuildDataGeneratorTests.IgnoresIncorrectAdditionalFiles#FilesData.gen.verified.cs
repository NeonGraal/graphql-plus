//HintName: FilesData.gen.cs
// Generated from Samples/Files
// Collected from IgnoresIncorrectAdditionalFiles

namespace GqlPlusTests;

public class SamplesFilesGqlData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "File3",
  ];

  public SamplesFilesGqlData()
  {
    foreach (string s in Strings) Add(s);
  }

  public const string From = "Samples/Files/Gql";
  public const string Collected = "IgnoresIncorrectAdditionalFiles";
}

public class SamplesFilesGraphqlData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "file2",
  ];

  public SamplesFilesGraphqlData()
  {
    foreach (string s in Strings) Add(s);
  }

  public const string From = "Samples/Files/Graphql";
  public const string Collected = "IgnoresIncorrectAdditionalFiles";
}
