using System.Text.Json;
using System.Text.Json.Serialization;

namespace GqlPlus.Rendering;

internal static class RenderJson
{
  internal static string Serialize(RenderStructure renderStructure)
    => JsonSerializer.Serialize(renderStructure, Options);

  private static JsonSerializerOptions Options { get; } = JsonOptions(true);

  internal static JsonSerializerOptions Unindented { get; } = JsonOptions(false);

  private static JsonSerializerOptions JsonOptions(bool indented)
    => new JsonSerializerOptions() {
      Converters = {
      new RenderStructureJsonConverter(),
        RenderStructureJsonConverter.ValueConverter,
      },
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = indented,
    };
}
