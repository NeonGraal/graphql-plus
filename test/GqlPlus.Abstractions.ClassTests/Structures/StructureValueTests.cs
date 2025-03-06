namespace GqlPlus.Structures;

public class StructureValueTests
{
  [Theory, RepeatData]
  public void IsEmpty_Identifier_IsFalse(string identifier)
  {
    StructureValue value = new(identifier);

    value.IsEmpty.Should().BeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Text_IsFalse(string text)
  {
    StructureValue value = StructureValue.Str(text);

    value.IsEmpty.Should().BeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Boolean_IsFalse(bool check)
  {
    StructureValue value = new(check);

    value.IsEmpty.Should().BeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Number_IsFalse(decimal number)
  {
    StructureValue value = new(number);

    value.IsEmpty.Should().BeFalse();
  }

  [Fact]
  public void IsEmpty_NummIdentifier_IsTrue()
  {
    string? identifier = null;

    StructureValue value = new(identifier);

    value.IsEmpty.Should().BeTrue();
  }

  [Fact]
  public void IsEmpty_NullText_IsTrue()
  {
    string? text = null;

    StructureValue value = StructureValue.Str(text);

    value.IsEmpty.Should().BeTrue();
  }

  [Fact]
  public void IsEmpty_NullBoolean_IsTrue()
  {
    bool? check = null;

    StructureValue value = new(check);

    value.IsEmpty.Should().BeTrue();
  }

  [Fact]
  public void IsEmpty_NullNumber_IsTrue()
  {
    decimal? number = null;

    StructureValue value = new(number);

    value.IsEmpty.Should().BeTrue();
  }

  [Fact]
  public void CompareTo_Empty_IsCorrect()
  {
    StructureValue value1 = new((string?)null);
    StructureValue value2 = new((decimal?)null);

    int result = value1.CompareTo(value2);

    result.Should().Be(-1);
  }

  [Fact]
  public void CompareTo_Null_IsCorrect()
  {
    StructureValue value = new((string?)null);

    int result = value.CompareTo(null);

    result.Should().Be(-1);
  }

  [Theory, RepeatData]
  public void CompareTo_Identifier_IsCorrect(string identifier1, string identifier2)
  {
    StructureValue value1 = new(identifier1);
    StructureValue value2 = new(identifier2);

    int result = value1.CompareTo(value2);

    result.Should().Be(string.Compare(identifier1, identifier2, StringComparison.Ordinal));
  }

  [Theory, RepeatData]
  public void CompareTo_Text_IsCorrect(string text1, string text2)
  {
    StructureValue value1 = StructureValue.Str(text1);
    StructureValue value2 = StructureValue.Str(text2);

    int result = value1.CompareTo(value2);

    result.Should().Be(string.Compare(text1, text2, StringComparison.Ordinal));
  }

  [Theory, RepeatData]
  public void CompareTo_Tag_IsCorrect(string tag1, string tag2)
  {
    StructureValue value1 = StructureValue.Str("a", tag1);
    StructureValue value2 = StructureValue.Str("a", tag2);

    int result = value1.CompareTo(value2);

    result.Should().Be(tag1 == tag2 ? 0 : -1);
  }

  [Theory, RepeatData]
  public void CompareTo_Boolean_IsCorrect(bool check1, bool check2)
  {
    StructureValue value1 = new(check1);
    StructureValue value2 = new(check2);

    int result = value1.CompareTo(value2);

    result.Should().Be(check1 ? check2 ? 0 : 1 : check2 ? -1 : 0);
  }

  [Theory, RepeatData]
  public void CompareTo_Number_IsCorrect(decimal number1, decimal number2)
  {
    StructureValue value1 = new(number1);
    StructureValue value2 = new(number2);

    int result = value1.CompareTo(value2);

    result.Should().Be(decimal.Compare(number1, number2));
  }

  [Fact]
  public void AsString_Empty_IsCorrect()
  {
    StructureValue value = new((string?)null);

    value.AsString.Should().Be("");
  }

  [Theory, RepeatData]
  public void AsString_Identifier_IsCorrect(string identifier)
  {
    StructureValue value = new(identifier);

    value.AsString.Should().Be(identifier);
  }

  [Theory, RepeatData]
  public void AsString_Text_IsCorrect(string text)
  {
    StructureValue value = StructureValue.Str(text);

    value.AsString.Should().Be(text);
  }

  [Theory, RepeatData]
  public void AsString_Boolean_IsCorrect(bool check)
  {
    StructureValue value = new(check);

    value.AsString.Should().Be(check.TrueFalse());
  }

  [Theory, RepeatData]
  public void AsString_Number_IsCorrect(decimal number)
  {
    StructureValue value = new(number);

    value.AsString.Should().Be($"{number}");
  }
}
