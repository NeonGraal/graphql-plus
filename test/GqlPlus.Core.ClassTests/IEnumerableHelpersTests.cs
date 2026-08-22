namespace GqlPlus;

public class IEnumerableHelpersTests
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
  public void NullEqual_NullInput_ReturnsTrue()
  {
    IEnumerable<int>? left = null;
    IEnumerable<int>? right = null;

    bool result = left.NullEqual(right);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void NullEqual_NonNullInput_ReturnsCorrect(int[] list)
  {
    IEnumerable<int>? left = null;
    IEnumerable<int>? right = [.. list];

    bool leftResult = left.NullEqual(list);
    bool rightResult = list.NullEqual(null);
    bool result = list.NullEqual(right);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeTrue(),
      () => leftResult.ShouldBeFalse(),
      () => rightResult.ShouldBeFalse());
  }

  [Fact]
  public void OrderedEqual_NullInput_ThrowsArgumentNullException()
  {
    IEnumerable<int>? left = null;
    IEnumerable<int>? right = null;

    Action result = () => left.ThrowIfNull().OrderedEqual(right.ThrowIfNull());

    result.ShouldThrow<ArgumentNullException>();
  }

  [Theory, RepeatData]
  public void Surround_NullInput_ReturnsEmptyString(string start, string end)
  {
    IEnumerable<string>? input = null;

    string result = input.Surround(start, end);

    result.ShouldBe(string.Empty);
  }

  [Theory, RepeatData]
  public void Surround_WithMapping_NullInput_ReturnsEmptyString(string start, string end)
  {
    IEnumerable<int>? input = null;

    string result = input.Surround(start, end, i => $"{i}");

    result.ShouldBe(string.Empty);
  }
}
