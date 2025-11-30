
namespace GqlPlus.Convert;

public class YamlValueWrappedTests
  : ConvertValueBase
{
  protected override string[] Convert(Structured model) => model.ToYaml(true).ToLines();

  protected override string[] Expected_Empty() => ["--- ''"];
  protected override string[] Expected_String(string value) => [value.QuotedIdentifier()];
  protected override string[] Expected_Identifier(string value) => [value];
  protected override string[] Expected_Punctuation(string value) => [value.QuotedIdentifier()];
  protected override string[] Expected_Decimal(decimal value) => [$"{value}"];
  protected override string[] Expected_Bool(bool value) => [value.ToString().ToLowerInvariant()];
}
