namespace GqlPlus;

public class SchemaValidData
  : TheoryData<string>
{
  // The Defintion specification has some schema definitions that are not valid schemas.
  public static readonly string SpecDefinition = "Definition";

  public static readonly string[] All = [
    .. SamplesSchemaGlobalData.Strings,
    .. SamplesSchemaMergeData.Strings,
    .. SamplesSchemaObjectData.Strings,
    .. SamplesSchemaSimpleData.Strings,
  ];

  public static readonly Dictionary<string, IEnumerable<string>> Files = new() {
    ["Global"] = SamplesSchemaGlobalData.Strings,
    ["Object"] = SamplesSchemaObjectData.Strings,
    ["Merge"] = SamplesSchemaMergeData.Strings,
    ["Simple"] = SamplesSchemaSimpleData.Strings,
  };

  public SchemaValidData()
  {
    foreach (string item in Files.Keys) {
      Add(item);
    }
  }
}
