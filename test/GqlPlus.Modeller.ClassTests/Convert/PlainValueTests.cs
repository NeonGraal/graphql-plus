namespace GqlPlus.Convert;

public class PlainValueTests()
  : ConvertValueTestsBase(PlainTestHelpers.Converters)
{
  protected override string[] Expected_Empty() => Tag.Tagged()("");
  protected override string[] Expected_String(string value) => Tag.Tagged()(value.QuotedIdentifier());
  protected override string[] Expected_Identifier(string value) => Tag.Tagged()(value);
  protected override string[] Expected_Punctuation(string value) => Tag.Tagged()(value.QuotedIdentifier());
  protected override string[] Expected_Decimal(decimal value) => Tag.Tagged()($"{value:0.#####}");
  protected override string[] Expected_Bool(bool value) => Tag.Tagged()(value.TrueFalse());
}
