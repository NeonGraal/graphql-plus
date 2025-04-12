namespace GqlPlus.Convert;

internal abstract class RenderJsonConverter<T>
  : JsonConverter<T>
{
  protected void WriteValue(Utf8JsonWriter writer, StructureValue value)
  {
    if (value.Identifier is not null) {
      writer.WriteStringValue(value.Identifier);
    } else if (value.Boolean is not null) {
      writer.WriteBooleanValue(value.Boolean.Value);
    } else if (value.Number is not null) {
      writer.WriteNumberValue(value.Number.Value);
    } else if (value.Text is not null) {
      writer.WriteStringValue(value.Text);
    }
  }

  protected void StartTaggedValue(Utf8JsonWriter writer, string tag)
  {
    writer.WriteStartObject();
    writer.WriteString("$tag", tag);
    writer.WritePropertyName("value");
  }
}
