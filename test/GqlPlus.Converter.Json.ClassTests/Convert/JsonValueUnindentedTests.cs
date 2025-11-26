
namespace GqlPlus.Convert;

public class JsonValueUnindentedTests
  : ConvertValueBase
{
  protected override string[] Convert(Structured model) => model.ToJson(RenderJson.Unindented).ToLines();

  protected override string[] Expected_Empty() => [];
  protected override string[] Expected_String(string value) => [value.Quoted('"')];
  protected override string[] Expected_Identifier(string value) => [value.Quoted('"')];
  protected override string[] Expected_Punctuation(string value) => [value.Quoted('"')];
  protected override string[] Expected_Decimal(decimal value) => [$"{value}"];
  protected override string[] Expected_Bool(bool value) => [value.ToString().ToLowerInvariant()];
}
