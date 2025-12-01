
namespace GqlPlus.Convert;

public class JsonValueUnindentedTests()
  : ConvertValueTestsBase(JsonTestHelpers.Unindented)
{
  protected override string[] Expected_Empty() => ["null"];
  protected override string[] Expected_String(string value) => [value.Quoted('"')];
  protected override string[] Expected_Identifier(string value) => [value.Quoted('"')];
  protected override string[] Expected_Punctuation(string value) => [value.Quoted('"')];
  protected override string[] Expected_Decimal(decimal value) => [$"{value}"];
  protected override string[] Expected_Bool(bool value) => [value.ToString().ToLowerInvariant()];
}
