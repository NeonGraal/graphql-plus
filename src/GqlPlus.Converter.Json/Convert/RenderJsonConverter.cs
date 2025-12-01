namespace GqlPlus.Convert;

internal abstract class RenderJsonConverter<T>
  : JsonConverter<T>
{
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
