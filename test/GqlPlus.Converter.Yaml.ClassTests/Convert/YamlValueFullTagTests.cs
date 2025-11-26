
namespace GqlPlus.Convert;

public class YamlValueFullTagTests
  : ConvertValueBase
{
  public YamlValueFullTagTests()
    => Tag = "tag";

  protected override string[] Convert(Structured model) => model.ToYaml(false).ToLines();

  protected override string[] Expected_Empty() => [$"--- !{Tag} ''"];
  protected override string[] Expected_String(string value) => [value.Quoted("'")];
  protected override string[] Expected_Identifier(string value) => Tag.WithFullTag(value);
  protected override string[] Expected_Punctuation(string value) => Tag.WithFullTag(value.Quoted("'"));
  protected override string[] Expected_Decimal(decimal value) => Tag.WithFullTag($"{value}");
  protected override string[] Expected_Bool(bool value) => Tag.WithFullTag(value.TrueFalse());
}
