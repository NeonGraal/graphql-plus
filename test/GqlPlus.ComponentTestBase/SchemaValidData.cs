namespace GqlPlus;

public class SchemaValidData
  : TheoryData<string>
{
  public static readonly SampleSchemaData Sample = [];

  public static readonly SchemaValidGlobalsData Globals = [];
  public static readonly SchemaValidSimpleData Simple = [];
  public static readonly SchemaValidObjectsData Objects = [];
  public static readonly SchemaValidMergesData Merges = [];

  public static readonly string[] All = [.. Merges, .. Objects, .. Globals, .. Simple];

  public static readonly Dictionary<string, IEnumerable<string>> Files = new() {
    ["Objects"] = Objects,
    ["Merges"] = Merges,
    ["Globals"] = Globals,
    ["Simple"] = Simple,
  };
  public SchemaValidData()
  {
    foreach (string item in Files.Keys) {
      Add(item);
    }
  }
}
