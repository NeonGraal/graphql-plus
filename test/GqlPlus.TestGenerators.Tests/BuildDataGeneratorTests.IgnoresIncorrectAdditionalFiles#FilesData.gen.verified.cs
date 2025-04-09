//HintName: FilesData.gen.cs
// Generated from Samples/Files
// Collected from IgnoresIncorrectAdditionalFiles

namespace GqlPlusTests;

public class SamplesFilesData
  : TheoryData<string>
{
  public static readonly string[] Strings = [
    "file2",
    "File3",
  ];

  public SamplesFilesData()
  {
    foreach (string s in Strings) Add(s);
  }

  public const string From = "Samples/Files/";
  public const string Collected = "IgnoresIncorrectAdditionalFiles";
}
