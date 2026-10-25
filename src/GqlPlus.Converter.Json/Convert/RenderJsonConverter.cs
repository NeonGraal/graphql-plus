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

  protected void WriteValueTagged(Utf8JsonWriter writer, IGqlpScalar value, string keyTag = "")
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

  protected void WriteValue(Utf8JsonWriter writer, IGqlpScalar value)
  {
    switch (value.Kind) {
      case GqlpScalarKind.Boolean:
        writer.WriteBooleanValue(value.BooleanValue!.Value);
        break;
      case GqlpScalarKind.Number:
        writer.WriteNumberValue(value.Number!.Value);
        break;
      case GqlpScalarKind.Identifier:
      case GqlpScalarKind.Text:
        if (string.IsNullOrEmpty(value.Text)) {
          writer.WriteNullValue();
        } else {
          writer.WriteStringValue(value.Text);
        }
        break;
    }
  }
}
