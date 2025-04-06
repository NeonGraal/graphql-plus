namespace GqlPlus.Convert;

internal class RenderValueJsonConverter
  : RenderJsonConverter<StructureValue>
{
  public override StructureValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
  public override void Write(Utf8JsonWriter writer, StructureValue value, JsonSerializerOptions options)
  {
    if (value is null || value.IsEmpty) {
      return;
    }

    if (string.IsNullOrWhiteSpace(value.Tag)) {
      WriteValue(writer, value);
      return;
    }

    writer.WriteStartObject();
    writer.WriteString("$tag", value.Tag);
    writer.WritePropertyName("value");
    WriteValue(writer, value);
    writer.WriteEndObject();
  }
}
