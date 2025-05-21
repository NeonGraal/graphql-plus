namespace GqlPlus.Convert;

public static class RenderJson
{
  private static JsonSerializerOptions Indented { get; } = JsonOptions(true);

  public static JsonSerializerOptions Unindented { get; } = JsonOptions(false);

  private static JsonSerializerOptions JsonOptions(bool indented)
    => new() {
      Converters = {
      new RenderStructureJsonConverter(),
        RenderStructureJsonConverter.ValueConverter,
      },
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = indented,
    };

  public static string ToJson(this Structured model, JsonSerializerOptions? options = null)
    => JsonSerializer.Serialize(model, options ?? Indented);
}
