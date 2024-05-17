using System.Text.Json;

namespace GqlPlus.Rendering;
internal class RenderStructureJsonConverter
  : RenderJsonConverter<RenderStructure>
{
  internal static RenderValueJsonConverter ValueConverter { get; } = new();

  public override RenderStructure? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
  public override void Write(Utf8JsonWriter writer, RenderStructure value, JsonSerializerOptions options)
  {
    if (value is null || value.IsEmpty) {
      return;
    }

    bool plain = string.IsNullOrWhiteSpace(value.Tag);

    if (value.List.Count > 0) {
      WriteList(writer, value.List, options);
      return;
    } else if (value.Map.Count > 0) {
      (RenderValue _, RenderStructure first) = value.Map.First();
      if (value.Map.Count == 1 && !plain && string.IsNullOrWhiteSpace(first.Tag) && first.Value is not null) {
        StartTaggedValue(writer, value.Tag);
        WriteValue(writer, first.Value, options);
        writer.WriteEndObject();
      } else {
        WriteMap(writer, value.Map, value.Tag, options);
      }
    } else if (value.Value is not null) {
      ValueConverter.Write(writer, value.Value, options);
    }
  }

  private void WriteMap(Utf8JsonWriter writer, Structured<RenderValue, RenderStructure>.IDict map, string tag, JsonSerializerOptions options)
  {
    writer.WriteStartObject();

    if (!string.IsNullOrWhiteSpace(tag)) {
      writer.WriteString("$tag", tag);
    }

    IEnumerable<(string, RenderStructure)> ordered = map
      .Select(kv => (key: kv.Key.AsString, kv.Value))
      .OrderBy(kv => kv.key);

    foreach ((string key, RenderStructure value) in ordered) {
      writer.WritePropertyName(key);
      Write(writer, value, options);
    }

    writer.WriteEndObject();
  }

  private void WriteList(Utf8JsonWriter writer, IList<RenderStructure> list, JsonSerializerOptions options)
  {
    if (list.All(i => i.Value is not null)) {
      string result = JsonSerializer.Serialize(list, RenderJson.Unindented);
      writer.WriteRawValue(result.Replace(",", ", ", StringComparison.Ordinal));
      return;
    }

    writer.WriteStartArray();
    foreach (RenderStructure item in list) {
      Write(writer, item, options);
    }

    writer.WriteEndArray();
  }
}
