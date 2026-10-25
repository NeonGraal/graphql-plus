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

  [Theory, RepeatData]
  public void TryGetBoolean_BooleanValue_ReturnsValue(bool expected)
  {
    TestComplexValue value = new(new ScalarValue(expected));

    value.TryGetBoolean(out bool? actual).ShouldBeTrue();
    actual.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void TryGetNumber_NumberValue_ReturnsValue(decimal expected)
  {
    TestComplexValue value = new(new ScalarValue(expected));

    value.TryGetNumber(out decimal? actual).ShouldBeTrue();
    actual.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void TryGetText_TextValue_ReturnsValue(string expected)
  {
    TestComplexValue value = new(expected);

    value.TryGetText(out string? actual).ShouldBeTrue();
    actual.ShouldBe(expected);
  }

  [Fact]
  public void TryGetList_ListValue_ReturnsList()
  {
    TestComplexValue item = new("value");
    TestComplexValue value = new([item]);

    value.TryGetList(out IEnumerable<IValue>? actual).ShouldBeTrue();
    actual.ShouldNotBeNull();
    actual.Single().ShouldBeSameAs(item);
  }

  [Fact]
  public void TryGetMap_MapValue_ReturnsMap()
  {
    ScalarValue key = new("key");
    TestComplexValue item = new("value");
    TestComplexValue value = new(key.DictWith(item));

    value.TryGetMap(out IMap<IValue>? actual).ShouldBeTrue();
    actual.ShouldNotBeNull();
    actual.GetValueOr("key").ShouldBeSameAs(item);
  }

  [Fact]
  public void ToString_EmptyValue_ReturnsTaggedEmptyValue()
  {
    TestComplexValue value = new([]) {
      Tag = "Empty",
    };

    value.ToString().ShouldBe("Empty()");
  }

  [Fact]
  public void ToString_ListValue_ReturnsFormattedList()
  {
    TestComplexValue value = new([
      new TestComplexValue("one"),
      new TestComplexValue("two"),
    ]) {
      Tag = "List",
    };

    value.ToString().ShouldBe("List![ one, two ]");
  }

  [Fact]
  public void ToString_MapValue_ReturnsFormattedMap()
  {
    ScalarValue key = new TestScalarValue("key");
    TestComplexValue value = new(key.DictWith(new TestComplexValue("value"))) {
      Tag = "Map",
    };

    value.ToString().ShouldBe("Map!{ key: value }");
  }

  [Fact]
  public void Equals_Empty_ShouldReturnTrue()
  {
    TestComplexValue testValue = new([]);
    TestComplexValue otherValue = new([]);

    testValue.Equals(otherValue).ShouldBeTrue();
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
      : this(new TestScalarValue(value))
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

    public override string ToString()
      => base.ToString();

    public override bool Equals(object obj)
      => base.Equals(obj);

    public override int GetHashCode()
      => base.GetHashCode();
  }

  private sealed class TestScalarValue(string value)
    : ScalarValue(value)
  {
    public override string ToString()
      => Text ?? "";
  }
}
