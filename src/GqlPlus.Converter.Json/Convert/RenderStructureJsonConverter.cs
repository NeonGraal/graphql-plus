namespace GqlPlus.Convert;

internal sealed class RenderStructureJsonConverter
  : RenderJsonConverter<Structured>
{
  internal static RenderValueJsonConverter ValueConverter { get; } = new();

  public override Structured? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    => new ReadJson().ReadStructured(ref reader).Result;
  public override void Write(Utf8JsonWriter writer, Structured value, JsonSerializerOptions options)
    => WriteStructureTagged(writer, value, "");

  private void WriteStructureTagged(Utf8JsonWriter writer, Structured value, string keyTag)
  {
    bool plain = string.IsNullOrWhiteSpace(value.Tag);

    if (value.List.Count > 0) {
      WriteList(writer, value.List, value.Tag, keyTag);
      return;
    }

    if (value.Map.Count > 0) {
      WriteMap(writer, value, keyTag, plain);
      return;
    }

    if (value.Value is not null) {
      WriteValueTagged(writer, value.Value, keyTag);
    }
  }

  private void WriteMap(Utf8JsonWriter writer, Structured value, string keyTag, bool plain)
  {
    KeyValuePair<StructureValue, Structured> first = value.Map.First();
    if (value.Map.Count == 1 && !plain && string.IsNullOrWhiteSpace(first.Value.Tag) && first.Value.Value is not null) {
      writer.WriteStartObject();
      WriteTag(writer, keyTag, "keyTag");
      WriteTag(writer, value.Tag, "mapTag");
      writer.WritePropertyName(first.Key.AsString);
      WriteStructureTagged(writer, first.Value.Value, first.Key.Tag);
      writer.WriteEndObject();
    } else {
      WriteFullMap(writer, value.Map, value.Tag, keyTag);
    }
  }

  private void WriteFullMap(Utf8JsonWriter writer, ComplexValue<StructureValue, Structured>.IDict map, string mapTag, string keyTag)
  {
    writer.WriteStartObject();
    WriteTag(writer, keyTag, "keyTag");
    WriteTag(writer, mapTag, "mapTag");
    IEnumerable<(StructureValue, Structured)> ordered = map
      .Select(kv => (key: kv.Key, kv.Value))
      .OrderBy(kv => kv.key.AsString, StringComparer.Ordinal);

    foreach ((StructureValue key, Structured value) in ordered) {
      writer.WritePropertyName(key.AsString);
      WriteStructureTagged(writer, value, key.Tag);
    }

    writer.WriteEndObject();
  }

  private void WriteList(Utf8JsonWriter writer, IList<Structured> list, string listTag, string keyTag = "")
  {
    if (string.IsNullOrWhiteSpace(listTag) && string.IsNullOrWhiteSpace(keyTag)) {
      if (list.All(i => i.Value is not null)) {
        string result = JsonSerializer.Serialize(list, RenderJson.Unindented);
        writer.WriteRawValue(result.Replace(",", ", "));
        return;
      }

      WriteList(writer, list);
      return;
    }

    writer.WriteStartObject();
    WriteTag(writer, keyTag, "keyTag");
    writer.WritePropertyName("$list");
    WriteList(writer, list);
    WriteTag(writer, listTag, "listTag");
    writer.WriteEndObject();
  }
  private void WriteList(Utf8JsonWriter writer, IList<Structured> list)
  {
    writer.WriteStartArray();
    foreach (Structured item in list) {
      WriteStructureTagged(writer, item, "");
    }

    writer.WriteEndArray();
  }
}
