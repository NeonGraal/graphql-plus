
namespace GqlPlus.Convert;

public class YamlValueFullTagTests
  : ConvertValueTestsBase
{
  public YamlValueFullTagTests()
    : base(YamlTestHelpers.Full)
    => Tag = "tag";

  protected override string[] Expected_Empty() => [$"--- !{Tag} ''"];
  protected override string[] Expected_String(string value) => Tag.Tagged(value.QuotedIdentifier());
  protected override string[] Expected_Identifier(string value) => Tag.Tagged(value);
  protected override string[] Expected_Punctuation(string value) => Tag.Tagged(value.QuotedIdentifier());
  protected override string[] Expected_Decimal(decimal value) => Tag.Tagged($"{value}");
  protected override string[] Expected_Bool(bool value) => Tag.Tagged(value.TrueFalse());
}
