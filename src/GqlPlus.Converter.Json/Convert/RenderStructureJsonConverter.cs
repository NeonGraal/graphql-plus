namespace GqlPlus.Convert;

internal sealed class RenderStructureJsonConverter
  : RenderJsonConverter<Structured>
{
  internal static RenderValueJsonConverter ValueConverter { get; } = new();

  public override Structured? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    => reader.TokenType switch {
      JsonTokenType.StartObject => ReadMap(ref reader, options),
      JsonTokenType.StartArray => ReadList(ref reader, options),
      _ => new(ReadValue(ref reader)),
    };
  public override void Write(Utf8JsonWriter writer, Structured value, JsonSerializerOptions options)
  {
    bool plain = string.IsNullOrWhiteSpace(value.Tag);

    if (value.List.Count > 0) {
      WriteList(writer, value.List, options);
      return;
    }

    if (value.Map.Count > 0) {
      WriteMap(writer, value, options, plain);
      return;
    }

    if (value.Value is not null) {
      ValueConverter.Write(writer, value.Value, options);
    }
  }

  private Structured ReadMap(ref Utf8JsonReader reader, JsonSerializerOptions options)
  {
    string tag = "";
    StructureValue? value = null;
    Dictionary<StructureValue, Structured> fields = [];
    while (reader.Read()) {
      if (reader.TokenType == JsonTokenType.EndObject) {
        break;
      }

      // Read the property name
      string propertyName = reader.GetString().IfWhiteSpace();
      reader.Read(); // Move to the value

      if (propertyName.Equals("$tag", StringComparison.Ordinal)) {
        tag = reader.GetString().IfWhiteSpace();
        continue;
      }

      if (propertyName.Equals("$value", StringComparison.Ordinal)) {
        value = ValueConverter.Read(ref reader, typeof(StructureValue), options);
        continue;
      }

      // Deserialize the value using the ValueConverter
      Structured field = Read(ref reader, typeof(Structured), options) ?? new("");

      fields.Add(new(propertyName), field);
    }

    if (value is not null) {
      value.Tag = tag;
      return new(value);
    }

    return new(fields, tag);
  }
  private void WriteMap(Utf8JsonWriter writer, Structured value, JsonSerializerOptions options, bool plain)
  {
    KeyValuePair<StructureValue, Structured> first = value.Map.First();
    if (value.Map.Count == 1 && !plain && string.IsNullOrWhiteSpace(first.Value.Tag) && first.Value.Value is not null) {
      writer.WriteStartObject();
      writer.WriteString("$tag", value.Tag);
      writer.WritePropertyName(first.Key.AsString);
      WriteValue(writer, first.Value.Value);
      writer.WriteEndObject();
    } else {
      WriteFullMap(writer, value.Map, value.Tag, options);
    }
  }

  private void WriteFullMap(Utf8JsonWriter writer, ComplexValue<StructureValue, Structured>.IDict map, string tag, JsonSerializerOptions options)
  {
    writer.WriteStartObject();

    if (!string.IsNullOrWhiteSpace(tag)) {
      writer.WriteString("$tag", tag);
    }

    IEnumerable<(string, Structured)> ordered = map
      .Select(kv => (key: kv.Key.AsString, kv.Value))
      .OrderBy(kv => kv.key, StringComparer.Ordinal);

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
  private Structured ReadList(ref Utf8JsonReader reader, JsonSerializerOptions options)
  {
    List<Structured> items = [];
    while (reader.Read()) {
      if (reader.TokenType == JsonTokenType.EndArray) {
        break;
      }

      Structured? item = Read(ref reader, typeof(Structured), options);
      if (item is not null) {
        items.Add(item);
      }
    }

    return new(items);
  }
}
