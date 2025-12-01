namespace GqlPlus.Convert;

public class YamlValueWrappedTagTests
  : ConvertValueTestsBase
{
  public YamlValueWrappedTagTests()
    : base(YamlTestHelpers.Wrapped)
    => Tag = "tag";

  protected override string[] Expected_Empty() => [$"--- !{Tag} ''"];
  protected override string[] Expected_String(string value) => Tag.WithWrappedTag(value.QuotedIdentifier());
  protected override string[] Expected_Identifier(string value) => Tag.WithWrappedTag(value);
  protected override string[] Expected_Punctuation(string value) => Tag.WithWrappedTag(value.QuotedIdentifier());
  protected override string[] Expected_Decimal(decimal value) => Tag.WithWrappedTag($"{value}");
  protected override string[] Expected_Bool(bool value) => Tag.WithWrappedTag(value.TrueFalse());
}
