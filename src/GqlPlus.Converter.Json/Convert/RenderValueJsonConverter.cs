namespace GqlPlus.Convert;

internal sealed class RenderValueJsonConverter
  : RenderJsonConverter<StructureValue>
{
  public override StructureValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    => reader.TokenType switch {
      JsonTokenType.StartObject => new ReadJson().ReadStructured(ref reader).Result?.Value,
      _ => ReadValue(ref reader),
    };

  public override void Write(Utf8JsonWriter writer, StructureValue value, JsonSerializerOptions options)
    => WriteValueTagged(writer, value);
}
