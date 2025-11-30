
namespace GqlPlus.Convert;

public class JsonValueIndentedTagTests
  : ConvertValueTestsBase
{
  public JsonValueIndentedTagTests()
    : base(JsonTestHelpers.Indented)
    => Tag = "tag";

  protected override string[] Expected_Empty() => Tag.WithIndentedValue("");
  protected override string[] Expected_String(string value) => Tag.WithIndentedValue(value.JsonValue());
  protected override string[] Expected_Identifier(string value) => Tag.WithIndentedValue(value.JsonValue());
  protected override string[] Expected_Punctuation(string value) => Tag.WithIndentedValue(value.JsonValue());
  protected override string[] Expected_Decimal(decimal value) => Tag.WithIndentedValue($"{value}");
  protected override string[] Expected_Bool(bool value) => Tag.WithIndentedValue(value.TrueFalse());
}
