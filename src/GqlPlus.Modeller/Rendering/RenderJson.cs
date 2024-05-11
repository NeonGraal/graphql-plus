using System.Text.Json;
using System.Text.Json.Serialization;

namespace GqlPlus.Rendering;

public static class RenderJson
{
  private static JsonSerializerOptions Options { get; } = JsonOptions(true);

  internal static JsonSerializerOptions Unindented { get; } = JsonOptions(false);

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

  public static string ToJson(this RenderStructure model)
    => JsonSerializer.Serialize(model, Options) + "\n";
}
