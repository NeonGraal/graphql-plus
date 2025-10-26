namespace GqlPlus;

public class ComplexValueTests
{
  [Fact]
  public void Empty_ShouldBeCorrect()
  {
    TestComplexValue value = new([]);

    value.ShouldSatisfyAllConditions(
      v => v.Tag.ShouldBeNullOrEmpty(),

      v => v.TryGetBoolean(out _).ShouldBeFalse(),
      v => v.TryGetNumber(out _).ShouldBeFalse(),
      v => v.TryGetText(out _).ShouldBeFalse(),
      v => v.TryGetList(out _).ShouldBeFalse(),
      v => v.TryGetMap(out _).ShouldBeFalse()
    );
  }

  [Fact]
  public void EmptyString_ShouldBeCorrect()
  {
    TestComplexValue value = new("");

    value.ShouldSatisfyAllConditions(
      v => v.Tag.ShouldBeNullOrEmpty(),

      v => v.TryGetBoolean(out _).ShouldBeFalse(),
      v => v.TryGetNumber(out _).ShouldBeFalse(),
      v => v.TryGetText(out _).ShouldBeFalse(),
      v => v.TryGetList(out _).ShouldBeFalse(),
      v => v.TryGetMap(out _).ShouldBeFalse()
    );
  }

  [Fact]
  public void Equals_Empty_ShouldReturnFalse()
  {
    TestComplexValue testValue = new([]);
    TestComplexValue otherValue = new([]);

    testValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Equals_WithList_ShouldReturnTrue(string value)
  {
    TestComplexValue testValue = new([new(value)]);
    TestComplexValue otherValue = new([new(value)]);

    testValue.Equals(otherValue).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_WithMap_ShouldReturnTrue(string key, string value)
  {
    ScalarValue keyValue = new(key);
    TestComplexValue testValue = new(keyValue.DictWith(new TestComplexValue(value)));
    TestComplexValue otherValue = new(keyValue.DictWith(new TestComplexValue(value)));

    testValue.Equals(otherValue).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_WithText_ShouldReturnTrue(string value)
  {
    TestComplexValue testValue = new(value);
    TestComplexValue otherValue = new(value);

    testValue.Equals(otherValue).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_Object_ShouldReturnFalse(string value)
  {
    TestComplexValue testValue = new(value);
    object otherValue = value;

    testValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithList_ShouldReturnFalse(string value)
  {
    TestComplexValue testValue = new([new(value)]);
    TestComplexValue otherValue = new([new(value + "Not")]);

    testValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithMapKey_ShouldReturnFalse(string key, string value)
  {
    ScalarValue keyValue = new(key);
    ScalarValue keyNot = new(key + "Not");
    TestComplexValue testValue = new(keyValue.DictWith(new TestComplexValue(value)));
    TestComplexValue otherValue = new(keyNot.DictWith(new TestComplexValue(value)));

    testValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithMapValue_ShouldReturnFalse(string key, string value)
  {
    ScalarValue keyValue = new(key);
    TestComplexValue testValue = new(keyValue.DictWith(new TestComplexValue(value)));
    TestComplexValue otherValue = new(keyValue.DictWith(new TestComplexValue(value + "Not")));

    testValue.Equals(otherValue).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void NotEquals_WithText_ShouldReturnFalse(string value)
  {
    TestComplexValue testValue = new(value);
    TestComplexValue otherValue = new(value + "Not");

    testValue.Equals(otherValue).ShouldBeFalse();
  }

  private sealed class TestComplexValue
    : ComplexValue<ScalarValue, TestComplexValue>
    , IEquatable<TestComplexValue>
  {
    public TestComplexValue(string value)
      : this(new ScalarValue(value))
    { }

    public TestComplexValue(ScalarValue value)
      : base(value)
    { }

    public TestComplexValue(IEnumerable<TestComplexValue> values)
      : base(values)
    { }

    public TestComplexValue(IDictionary<ScalarValue, TestComplexValue> values)
      : base(values)
    { }

    public bool Equals(TestComplexValue? other)
      => base.Equals(other);

    public override bool Equals(object obj)
      => base.Equals(obj);

    public override int GetHashCode()
      => base.GetHashCode();
  }
}
