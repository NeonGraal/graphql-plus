using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Convert;

internal sealed class RenderValueJsonConverter
  : RenderJsonConverter<StructureValue>
{
  [ExcludeFromCodeCoverage]
  public override StructureValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
  public override void Write(Utf8JsonWriter writer, StructureValue value, JsonSerializerOptions options)
  {
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
