namespace GqlPlus;

public class SchemaValidData
  : TheoryData<string>
{
  private static readonly SamplesSchemaData s_sample = [];
  private static readonly SamplesSchemaValidGlobalsData s_globals = [];
  private static readonly SamplesSchemaValidSimpleData s_simple = [];
  private static readonly SamplesSchemaValidObjectsData s_objects = [];
  private static readonly SamplesSchemaValidMergesData s_merges = [];

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
