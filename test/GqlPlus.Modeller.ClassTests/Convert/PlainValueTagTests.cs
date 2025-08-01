namespace GqlPlus.Convert;

public class PlainValueTagTests
  : PlainValueBase
{
  protected override string Tag => "tag";
  protected override string[] Expected_Empty() => [];
  protected override string[] Expected_String(string value) => ["!tag " + value.Quoted("'")];
  protected override string[] Expected_Identifier(string value) => ["!tag " + value];
  protected override string[] Expected_Punctuation(string value) => ["!tag '" + value + "'"];
  protected override string[] Expected_Decimal(decimal value) => [$"!tag {value:0.#####}"];
  protected override string[] Expected_Bool(bool value) => ["!tag " + value.ToString().ToLowerInvariant()];
}
