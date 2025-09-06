namespace GqlPlus;

public class SchemaValidData
  : TheoryData<string>
{
  // The Defintion specification has some schema definitions that are not valid schemas.
  public static readonly string SpecDefinition = "Definition";

  public static bool ExcludeSpecsForBuiltIn(string test)
    => test == SpecDefinition || test == "Schema";

  public static readonly string[] All = [
    .. SamplesSchemaGlobalsData.Strings,
    .. SamplesSchemaMergesData.Strings,
    .. SamplesSchemaObjectsData.Strings,
    .. SamplesSchemaSimpleData.Strings,
  ];

  public static readonly Dictionary<string, IEnumerable<string>> Files = new() {
    ["Globals"] = SamplesSchemaGlobalsData.Strings,
    ["Objects"] = SamplesSchemaObjectsData.Strings,
    ["Merges"] = SamplesSchemaMergesData.Strings,
    ["Simple"] = SamplesSchemaSimpleData.Strings,
  };

  public SchemaValidData()
  {
    foreach (string item in Files.Keys) {
      Add(item);
    }
  }
}
