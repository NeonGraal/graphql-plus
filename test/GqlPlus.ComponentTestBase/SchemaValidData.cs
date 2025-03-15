namespace GqlPlus;

public class SchemaValidData
  : TheoryData<string>
{
  public static readonly string[] All = [
    .. SamplesSchemaValidGlobalsData.Strings,
    .. SamplesSchemaValidMergesData.Strings,
    .. SamplesSchemaValidObjectsData.Strings,
    .. SamplesSchemaValidSimpleData.Strings,
  ];

  public static readonly Dictionary<string, IEnumerable<string>> Files = new() {
    ["Globals"] = SamplesSchemaValidGlobalsData.Strings,
    ["Objects"] = SamplesSchemaValidObjectsData.Strings,
    ["Merges"] = SamplesSchemaValidMergesData.Strings,
    ["Simple"] = SamplesSchemaValidSimpleData.Strings,
  };

  public SchemaValidData()
  {
    foreach (string item in Files.Keys) {
      Add(item);
    }
  }
}
