namespace GqlPlus.Convert;

internal abstract class RenderJsonConverter<T>
  : JsonConverter<T>
{
  protected void WriteTag(Utf8JsonWriter writer, string tag, string tagName)
  {
    if (!string.IsNullOrWhiteSpace(tag)) {
      writer.WriteString("$" + tagName, tag);
    }
  }

  protected void WriteValueTagged(Utf8JsonWriter writer, StructureValue value, string keyTag = "")
  {
    if (string.IsNullOrWhiteSpace(value.Tag) && string.IsNullOrWhiteSpace(keyTag)) {
      WriteValue(writer, value);
      return;
    }

    writer.WriteStartObject();
    WriteTag(writer, keyTag, "keyTag");
    writer.WritePropertyName("$value");
    WriteValue(writer, value);
    WriteTag(writer, value.Tag, "valueTag");
    writer.WriteEndObject();
  }

  protected void WriteValue(Utf8JsonWriter writer, StructureValue value)
  {
    if (!string.IsNullOrWhiteSpace(value.Identifier)) {
      writer.WriteStringValue(value.Identifier);
    } else if (value.Boolean is not null) {
      writer.WriteBooleanValue(value.Boolean.Value);
    } else if (value.Number is not null) {
      writer.WriteNumberValue(value.Number.Value);
    } else if (!string.IsNullOrEmpty(value.Text)) {
      writer.WriteStringValue(value.Text);
    } else {
      writer.WriteNullValue();
    }
  }
}
