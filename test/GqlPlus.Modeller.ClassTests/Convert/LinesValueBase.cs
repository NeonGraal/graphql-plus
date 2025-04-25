using System.ComponentModel.DataAnnotations;
using GqlPlus.Structures;
using Shouldly;

namespace GqlPlus.Convert;

public abstract class LinesValueBase
{
  protected abstract string Tag { get; }
  protected abstract string Expected_Empty();
  protected abstract string Expected_String(string value);
  protected abstract string Expected_Identifier(string value);
  protected abstract string Expected_Punctuation(string value);
  protected abstract string Expected_Decimal(decimal value);
  protected abstract string Expected_Bool(bool value);

  [Fact]
  public void ToLines_Empty()
  {
    Structured model = new("", Tag);
    string expected = Expected_Empty();

    string result = model.ToLines(false);

    result.ShouldBe(string.Empty);
  }

  [Theory, RepeatData]
  public void ToLines_String(string value)
  {
    string expected = Expected_String(value).IsLine();
    Structured model = new(StructureValue.Str(value, Tag));

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_Identifier(string value)
  {
    string expected = Expected_Identifier(value).IsLine();
    Structured model = new(value, Tag);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_Punctuation([RegularExpression(@"[{}[\]&#*?|\-<>=!%@:`,]")] string value)
  {
    string expected = Expected_Punctuation(value).IsLine();
    Structured model = new(value, Tag);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_Decimal(decimal value)
  {
    string expected = Expected_Decimal(value).IsLine();
    Structured model = new(value, Tag);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_Bool(bool value)
  {
    string expected = Expected_Bool(value).IsLine();
    Structured model = new(value, Tag);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }
}
