﻿using System.Text.Json;

namespace GqlPlus.Convert;
internal class RenderStructureJsonConverter
  : RenderJsonConverter<Structured>
{
  internal static RenderValueJsonConverter ValueConverter { get; } = new();

  public override Structured? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
  public override void Write(Utf8JsonWriter writer, Structured value, JsonSerializerOptions options)
  {
    if (value is null || value.IsEmpty) {
      return;
    }

    bool plain = string.IsNullOrWhiteSpace(value.Tag);

    if (value.List.Count > 0) {
      WriteList(writer, value.List, options);
      return;
    } else if (value.Map.Count > 0) {
      Structured first = value.Map.First().Value;
      if (value.Map.Count == 1 && !plain && string.IsNullOrWhiteSpace(first.Tag) && first.Value is not null) {
        StartTaggedValue(writer, value.Tag);
        WriteValue(writer, first.Value);
        writer.WriteEndObject();
      } else {
        WriteMap(writer, value.Map, value.Tag, options);
      }
    } else if (value.Value is not null) {
      ValueConverter.Write(writer, value.Value, options);
    }
  }

  private void WriteMap(Utf8JsonWriter writer, Structured<StructureValue, Structured>.IDict map, string tag, JsonSerializerOptions options)
  {
    writer.WriteStartObject();

    if (!string.IsNullOrWhiteSpace(tag)) {
      writer.WriteString("$tag", tag);
    }

    IEnumerable<(string, Structured)> ordered = map
      .Select(kv => (key: kv.Key.AsString, kv.Value))
      .OrderBy(kv => kv.key);

    foreach ((string key, Structured value) in ordered) {
      writer.WritePropertyName(key);
      Write(writer, value, options);
    }

    writer.WriteEndObject();
  }

  private void WriteList(Utf8JsonWriter writer, IList<Structured> list, JsonSerializerOptions options)
  {
    if (list.All(i => i.Value is not null)) {
      string result = JsonSerializer.Serialize(list, RenderJson.Unindented);
      writer.WriteRawValue(result.Replace(",", ", "));
      return;
    }

    writer.WriteStartArray();
    foreach (Structured item in list) {
      Write(writer, item, options);
    }

    writer.WriteEndArray();
  }
}
