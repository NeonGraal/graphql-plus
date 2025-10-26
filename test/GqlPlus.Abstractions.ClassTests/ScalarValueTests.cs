namespace GqlPlus;

public class ScalarValueTests
{
  [Fact]
  public void Empty_ShouldBeCorrect()
  {
    ScalarValue value = new((string?)null);

    value.ShouldSatisfyAllConditions(
      v => v.IsEmpty.ShouldBeTrue(),
      v => v.Boolean.ShouldBeNull(),
      v => v.Number.ShouldBeNull(),
      v => v.Text.ShouldBeNullOrEmpty(),
      v => v.Tag.ShouldBeNullOrEmpty(),

      v => v.TryGetBoolean(out _).ShouldBeFalse(),
      v => v.TryGetNumber(out _).ShouldBeFalse(),
      v => v.TryGetText(out _).ShouldBeFalse(),
      v => v.TryGetList(out _).ShouldBeFalse(),
      v => v.TryGetMap(out _).ShouldBeFalse()
    );
  }

  [Fact]
  public void Whitespace_ShouldBeCorrect()
  {
    ScalarValue value = new("");

    value.ShouldSatisfyAllConditions(
      v => v.IsEmpty.ShouldBeTrue(),
      v => v.Boolean.ShouldBeNull(),
      v => v.Number.ShouldBeNull(),
      v => v.Text.ShouldBeNullOrEmpty(),
      v => v.Tag.ShouldBeNullOrEmpty(),

      v => v.TryGetBoolean(out _).ShouldBeFalse(),
      v => v.TryGetNumber(out _).ShouldBeFalse(),
      v => v.TryGetText(out _).ShouldBeFalse(),
      v => v.TryGetList(out _).ShouldBeFalse(),
      v => v.TryGetMap(out _).ShouldBeFalse()
    );
  }

  [Fact]
  public void Equals_WithNull_ShouldReturnFalse()
  {
    ScalarValue scalarValue = new((string?)null);
    ScalarValue otherValue = new((string?)null);

    scalarValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Equals_WithBool_ShouldReturnTrue(bool value)
  {
    ScalarValue scalarValue = new(value);
    ScalarValue otherValue = new(value);

    scalarValue.Equals(otherValue).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_WithNumber_ShouldReturnTrue(decimal value)
  {
    ScalarValue scalarValue = new(value);
    ScalarValue otherValue = new(value);

    scalarValue.Equals(otherValue).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_WithText_ShouldReturnTrue(string value)
  {
    ScalarValue scalarValue = new(value);
    ScalarValue otherValue = new(value);

    scalarValue.Equals(otherValue).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_Object_ShouldReturnFalse(string value)
  {
    ScalarValue scalarValue = new(value);
    object otherValue = value;

    scalarValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithBool_ShouldReturnFalse(bool value)
  {
    ScalarValue scalarValue = new(value);
    ScalarValue otherValue = new(!value);

    scalarValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithNum_ShouldReturnFalse(decimal value)
  {
    ScalarValue scalarValue = new(value);
    ScalarValue otherValue = new(value + 1);

    scalarValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithText_ShouldReturnFalse(string value)
  {
    ScalarValue scalarValue = new(value);
    ScalarValue otherValue = new(value + "Not");

    scalarValue.Equals(otherValue).ShouldBeFalse();
  }
}
