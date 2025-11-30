namespace GqlPlus.Convert;

public class YamlValueWrappedTagTests
  : ConvertValueBase
{
  public YamlValueWrappedTagTests()
    => Tag = "tag";

  protected override string[] Convert(Structured model) => model.ToYaml(true).ToLines();

  protected override string[] Expected_Empty() => [$"--- !{Tag} ''"];
  protected override string[] Expected_String(string value) => Tag.WithFullTag(value.QuotedIdentifier());
  protected override string[] Expected_Identifier(string value) => Tag.WithWrappedTag(value);
  protected override string[] Expected_Punctuation(string value) => [value.QuotedIdentifier()];
  protected override string[] Expected_Decimal(decimal value) => Tag.WithWrappedTag($"{value}");
  protected override string[] Expected_Bool(bool value) => Tag.WithWrappedTag(value.TrueFalse());
}
