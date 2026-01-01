namespace GqlPlus.Convert.Json;

public class JsonValueUnindentedTagTests
  : ValueConvertTestsBase
{
  public JsonValueUnindentedTagTests()
    : base(JsonTestHelpers.Unindented)
    => Tag = "tag";

  protected override string[] Expected_Empty() => [Tag.WithUnindentedValue("null")];
  protected override string[] Expected_String(string value) => [Tag.WithUnindentedValue(value.JsonValue())];
  protected override string[] Expected_Identifier(string value) => [Tag.WithUnindentedValue(value.JsonValue())];
  protected override string[] Expected_Punctuation(string value) => [Tag.WithUnindentedValue(value.JsonValue())];
  protected override string[] Expected_Decimal(decimal value) => [Tag.WithUnindentedValue($"{value}")];
  protected override string[] Expected_Bool(bool value) => [Tag.WithUnindentedValue(value.TrueFalse())];
}
