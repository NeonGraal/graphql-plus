namespace GqlPlus.Convert.SimpleYaml;

public class SimpleYamlValueTests()
  : ValueConvertToTestsBase(SimpleYamlTestHelpers.Converters)
{
  protected override string[] Expected_Empty() => [];
  protected override string[] Expected_String(string value) => [value.QuotedIdentifier()];
  protected override string[] Expected_Identifier(string value) => [value];
  protected override string[] Expected_Punctuation(string value) => [$"'{value}'"];
  protected override string[] Expected_Decimal(decimal value) => [$"{value:0.#####}"];
  protected override string[] Expected_Bool(bool value) => [value.TrueFalse()];
}
