namespace GqlPlus.Convert;

internal sealed class RenderValueJsonConverter
  : RenderJsonConverter<StructureValue>
{
  public override StructureValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    => reader.TokenType switch {
      JsonTokenType.StartObject => ReadTagged(ref reader),
      _ => ReadValue(ref reader),
    };

  public override void Write(Utf8JsonWriter writer, StructureValue value, JsonSerializerOptions options)
  {
    if (string.IsNullOrWhiteSpace(value.Tag)) {
      WriteValue(writer, value);
      return;
    }

    writer.WriteStartObject();
    writer.WriteString("$tag", value.Tag);
    writer.WritePropertyName("$value");
    WriteValue(writer, value);
    writer.WriteEndObject();
  }

  private StructureValue? ReadTagged(ref Utf8JsonReader reader)
  {
    string tag = "";
    StructureValue? value = null;
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
        value = ReadValue(ref reader);
        continue;
      }
    }

    value?.Tag = tag;
    return value;
  }
}
