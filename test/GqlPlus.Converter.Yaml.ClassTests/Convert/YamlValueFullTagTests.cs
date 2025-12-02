
namespace GqlPlus.Convert;

public class YamlValueFullTagTests
  : ConvertValueTestsBase
{
  public YamlValueFullTagTests()
    : base(YamlTestHelpers.Full)
    => Tag = "tag";

  protected override string[] Expected_Empty() => [$"--- !{Tag} ''"];
  protected override string[] Expected_String(string value) => Tag.WithFullTag(value.QuotedIdentifier());
  protected override string[] Expected_Identifier(string value) => Tag.WithFullTag(value);
  protected override string[] Expected_Punctuation(string value) => Tag.WithFullTag(value.QuotedIdentifier());
  protected override string[] Expected_Decimal(decimal value) => Tag.WithFullTag($"{value}");
  protected override string[] Expected_Bool(bool value) => Tag.WithFullTag(value.TrueFalse());
}
