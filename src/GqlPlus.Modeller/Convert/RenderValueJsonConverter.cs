using System.Text.Json;

namespace GqlPlus.Convert;

internal class RenderValueJsonConverter
  : RenderJsonConverter<RenderValue>
{
  public override RenderValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
  public override void Write(Utf8JsonWriter writer, RenderValue value, JsonSerializerOptions options)
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
