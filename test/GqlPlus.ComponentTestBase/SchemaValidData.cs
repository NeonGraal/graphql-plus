namespace GqlPlus;

public class SchemaValidData
  : TheoryData<string>
{
  private static readonly SampleSchemaData s_sample = [];
  private static readonly SchemaValidGlobalsData s_globals = [];
  private static readonly SchemaValidSimpleData s_simple = [];
  private static readonly SchemaValidObjectsData s_objects = [];
  private static readonly SchemaValidMergesData s_merges = [];

  public static IEnumerable<string> Sample => s_sample.Select(x => x.Data);
  public static IEnumerable<string> Globals => s_globals.Select(x => x.Data);
  public static IEnumerable<string> Simple => s_simple.Select(x => x.Data);
  public static IEnumerable<string> Objects => s_objects.Select(x => x.Data);
  public static IEnumerable<string> Merges => s_merges.Select(x => x.Data);

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
