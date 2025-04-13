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

    result.ShouldBe(string.Empty);
  }

  [Fact]
  public void Joined_WithMapping_NullInput_ReturnsEmptyString()
  {
    IEnumerable<int?>? input = null;

    string result = input.Joined(i => $"{i}");

    result.ShouldBe(string.Empty);
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

    result.ShouldBe(string.Empty);
  }

  [Fact]
  public void Suffixed_NullInput_ReturnsEmptyString()
  {
    string? input = null;

    string result = input.Suffixed("suffix");

    result.ShouldBe(string.Empty);
  }

  [Fact]
  public void Quoted_NullInput_ReturnsEmptyString()
  {
    string? input = null;

    string result = input.Quoted("\"");

    result.ShouldBe(string.Empty);
  }

  [Fact]
  public void Surround_NullInput_ReturnsEmptyString()
  {
    IEnumerable<string>? input = null;

    string result = input.Surround("[", "]");

    result.ShouldBe("");
  }

  [Fact]
  public void Surround_WithMapping_NullInput_ReturnsEmptyString()
  {
    IEnumerable<int>? input = null;

    string result = input.Surround("[", "]", i => $"{i}");

    result.ShouldBe("");
  }
}
