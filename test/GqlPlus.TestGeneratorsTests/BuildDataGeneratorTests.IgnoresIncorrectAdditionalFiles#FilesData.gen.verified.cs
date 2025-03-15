//HintName: FilesData.gen.cs
// Generated from Samples/Files
// Collected from IgnoresIncorrectAdditionalFiles

namespace GqlPlusTests;

public class SamplesFilesData
  : TheoryData<string>
{
  public SamplesFilesData()
  {
    Add("file2");
    Add("File3");
  }

  public const string From = "Samples/Files/";
  public const string Collected = "IgnoresIncorrectAdditionalFiles";
}
