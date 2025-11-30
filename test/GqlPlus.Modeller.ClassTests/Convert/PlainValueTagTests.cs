
namespace GqlPlus.Convert;

public class PlainValueTagTests
  : ConvertValueBase
{
  public PlainValueTagTests() => Tag = "tag";

  protected override string[] Convert(Structured model) => model.ToPlain(false);

  protected override string[] Expected_Empty() => [];
  protected override string[] Expected_String(string value) => [$"!{Tag} " + value.QuotedIdentifier()];
  protected override string[] Expected_Identifier(string value) => [$"!{Tag} {value}"];
  protected override string[] Expected_Punctuation(string value) => [$"!{Tag} '{value}'"];
  protected override string[] Expected_Decimal(decimal value) => [$"!{Tag} {value:0.#####}"];
  protected override string[] Expected_Bool(bool value) => [$"!{Tag} {value.TrueFalse()}"];
}
