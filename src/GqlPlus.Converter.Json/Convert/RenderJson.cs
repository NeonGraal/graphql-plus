namespace GqlPlus.Convert;

public static class RenderJson
{
  private static JsonSerializerOptions Indented { get; } = JsonOptions(true);

  public static JsonSerializerOptions Unindented { get; } = JsonOptions(false);

  private static JsonSerializerOptions JsonOptions(bool indented)
    => new() {
      Converters = { new RenderStructureJsonConverter(), },
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = indented,
    };

  public static string ToJson(this Structured model, JsonSerializerOptions? options = null)
    => JsonSerializer.Serialize(model, options ?? Indented);
  public static Structured FromJson(this IEnumerable<string> json, JsonSerializerOptions? options = null)
  {
    string joined = json.Joined(Environment.NewLine);
    Structured? result = string.IsNullOrWhiteSpace(joined) ? null
      : JsonSerializer.Deserialize<Structured>(joined, options ?? Indented);
    return result ?? new Structured("");
  }
}
