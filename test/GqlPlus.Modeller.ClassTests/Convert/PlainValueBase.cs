﻿using System.ComponentModel.DataAnnotations;

namespace GqlPlus.Convert;

public abstract class PlainValueBase
{
  protected abstract string Tag { get; }
  protected abstract string[] Expected_Empty();
  protected abstract string[] Expected_String(string value);
  protected abstract string[] Expected_Identifier(string value);
  protected abstract string[] Expected_Punctuation(string value);
  protected abstract string[] Expected_Decimal(decimal value);
  protected abstract string[] Expected_Bool(bool value);

  [Fact]
  public void ToPlain_Empty()
  {
    Structured model = new("", Tag);
    string[] expected = Expected_Empty();

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_String(string value)
  {
    string[] expected = Expected_String(value);
    Structured model = new(StructureValue.Str(value, Tag));

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_Identifier(string value)
  {
    string[] expected = Expected_Identifier(value);
    Structured model = new(value, Tag);

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_Punctuation([RegularExpression(@"[{}[\]&#*?|\-<>=!%@:`,]")] string value)
  {
    string[] expected = Expected_Punctuation(value);
    Structured model = new(value, Tag);

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_Decimal(decimal value)
  {
    string[] expected = Expected_Decimal(value);
    Structured model = new(value, Tag);

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_Bool(bool value)
  {
    string[] expected = Expected_Bool(value);
    Structured model = new(value, Tag);

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }
}
