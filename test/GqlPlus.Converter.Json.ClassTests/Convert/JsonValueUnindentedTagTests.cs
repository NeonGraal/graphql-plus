namespace GqlPlus.Convert;

public class JsonValueUnindentedTagTests
  : ConvertValueBase
{
  public JsonValueUnindentedTagTests()
    => Tag = "tag";

  protected override string[] Convert(Structured model) => model.ToJson(RenderJson.Unindented).ToLines();

  protected override string[] Expected_Empty() => [Tag.WithUnindentedValue("")];
  protected override string[] Expected_String(string value) => [Tag.WithUnindentedValue(value.JsonValue())];
  protected override string[] Expected_Identifier(string value) => [Tag.WithUnindentedValue(value.JsonValue())];
  protected override string[] Expected_Punctuation(string value) => [Tag.WithUnindentedValue(value.JsonValue())];
  protected override string[] Expected_Decimal(decimal value) => [Tag.WithUnindentedValue($"{value}")];
  protected override string[] Expected_Bool(bool value) => [Tag.WithUnindentedValue(value.TrueFalse())];
}
