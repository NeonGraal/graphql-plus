﻿using NSubstitute;

namespace GqlPlus;

public class GeneralHelpersTests
{
  [Fact]
  public void ArrayOf_NullInput_ReturnsEmptyArray()
  {
    IEnumerable<object>? input = null;

    string[] result = input.ArrayOf<string>();

    result.ShouldSatisfyAllConditions(
      r => r.ShouldNotBeNull(),
      r => r.ShouldBeEmpty());
  }

  [Fact]
  public void Joined_NullInput_ReturnsEmptyString()
  {
    IEnumerable<string?>? input = null;

    string result = input.Joined();

    result.ShouldBe("");
  }

  [Fact]
  public void Joined_WithMapping_NullInput_ReturnsEmptyString()
  {
    IEnumerable<int?>? input = null;

    string result = input.Joined(i => $"{i}");

    result.ShouldBe("");
  }

  [Fact]
  public void ThrowIfNull_NullValue_ThrowsArgumentNullException()
  {
    string? input = null;

    Action result = () => input.ThrowIfNull();

    result.ShouldThrow<ArgumentNullException>()
      .ParamName.ShouldBe(nameof(input));
  }

  [Fact]
  public void OrderedEqual_NullInput_ThrowsArgumentNullException()
  {
    IEnumerable<int>? left = null;
    IEnumerable<int>? right = null;

    Action result = () => left.ThrowIfNull().OrderedEqual(right.ThrowIfNull());

    result.ShouldThrow<ArgumentNullException>();
  }

  [Fact]
  public void Prefixed_NullInput_ReturnsEmptyString()
  {
    string? input = null;

    string result = input.Prefixed("prefix");

    result.ShouldBe("");
  }

  [Fact]
  public void Suffixed_NullInput_ReturnsEmptyString()
  {
    string? input = null;

    string result = input.Suffixed("suffix");

    result.ShouldBe("");
  }

  [Fact]
  public void Quoted_NullInput_ReturnsEmptyString()
  {
    string? input = null;

    string result = input.Quoted('"');

    result.ShouldBe("");
  }

  [Fact]
  public void Show_Null_ReturnsCorrect()
  {
    IGqlpAbbreviated? input = null;

    string result = input.Show();

    result.ShouldBe("");
  }

  [Fact]
  public void Show_Various_ReturnsCorrect()
  {
    IGqlpAbbreviated input = Substitute.For<IGqlpAbbreviated>();
    input.GetFields().Returns(["field1", "(", "field2", ")", "", "field3"]);

    string result = input.Show();

    result.ToLines().ShouldBe(["field1", "(", "  field2", ")", "field3"]);
  }

  [Fact]
  public void Surround_NullInput_ReturnsEmptyStringWithSurrounding()
  {
    IEnumerable<string>? input = null;

    string result = input.Surround("[", "]");

    result.ShouldBe("[]");
  }

  [Fact]
  public void Surround_WithMapping_NullInput_ReturnsEmptyStringWithSurrounding()
  {
    IEnumerable<int>? input = null;

    string result = input.Surround("[", "]", i => $"{i}");

    result.ShouldBe("[]");
  }
}
