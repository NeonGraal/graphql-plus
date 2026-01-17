using System.Diagnostics.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace GqlPlus.Structures;

public class StructureValueTests
{
  [Theory, RepeatData]
  public void IsEmpty_Identifier_IsFalse(string identifier)
  {
    StructureValue value = new(identifier);

    value.IsEmpty.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Text_IsFalse(string text)
  {
    this.SkipIf(text.IsIdentifier());
    StructureValue value = new(text);

    value.IsEmpty.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Boolean_IsFalse(bool check)
  {
    StructureValue value = new(check);

    value.IsEmpty.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Number_IsFalse(decimal number)
  {
    StructureValue value = new(number);

    value.IsEmpty.ShouldBeFalse();
  }

  [Fact]
  public void IsEmpty_NullString_IsTrue()
  {
    string? identifier = null;

    StructureValue value = new(identifier);

    value.IsEmpty.ShouldBeTrue();
  }

  [Fact]
  public void IsEmpty_NullBoolean_IsTrue()
  {
    bool? check = null;

    StructureValue value = new(check);

    value.IsEmpty.ShouldBeTrue();
  }

  [Fact]
  public void IsEmpty_NullNumber_IsTrue()
  {
    decimal? number = null;

    StructureValue value = new(number);

    value.IsEmpty.ShouldBeTrue();
  }

  [Fact]
  public void CompareTo_Empty_IsCorrect()
  {
    StructureValue value1 = new((string?)null);
    StructureValue value2 = new((decimal?)null);

    int result = value1.CompareTo(value2);

    result.ShouldBe(0);
  }

  [Fact]
  public void CompareTo_Null_IsCorrect()
  {
    StructureValue value = new((string?)null);

    int result = value.CompareTo(null);

    result.ShouldBe(-1);
  }

  [Theory, RepeatData]
  public void CompareTo_Identifier_IsCorrect(string identifier1, string identifier2)
  {
    StructureValue value1 = new(identifier1);
    StructureValue value2 = new(identifier2);

    int result = value1.CompareTo(value2);

    result.ShouldBe(identifier1.Compare(identifier2));
  }

  [Theory, RepeatData]
  public void CompareTo_Text_IsCorrect(string text1, string text2)
  {
    this.SkipIf(text1.IsIdentifier());
    this.SkipIf(text2.IsIdentifier());

    StructureValue value1 = new(text1);
    StructureValue value2 = new(text2);

    int result = value1.CompareTo(value2);

    result.ShouldBe(text1.Compare(text2));
  }

  [Theory, RepeatData]
  public void CompareTo_Tag_IsCorrect(string tag1, string tag2)
  {
    StructureValue value1 = new("a", tag1);
    StructureValue value2 = new("a", tag2);

    int result = value1.CompareTo(value2);

    result.ShouldBe(tag1 == tag2 ? 0 : -1);
  }

  [Theory, RepeatData]
  public void CompareTo_Boolean_IsCorrect(bool check1, bool check2)
  {
    StructureValue value1 = new(check1);
    StructureValue value2 = new(check2);

    int result = value1.CompareTo(value2);

    result.ShouldBe(check1 ? check2 ? 0 : 1 : check2 ? -1 : 0);
  }

  [Theory, RepeatData]
  public void CompareTo_Number_IsCorrect(decimal number1, decimal number2)
  {
    StructureValue value1 = new(number1);
    StructureValue value2 = new(number2);

    int result = value1.CompareTo(value2);

    result.ShouldBe(decimal.Compare(number1, number2));
  }

  [Fact]
  public void Equals_Empty_IsCorrect()
  {
    StructureValue value1 = new((string?)null);
    StructureValue value2 = new((decimal?)null);

    bool result = value1.Equals(value2);

    result.ShouldBeTrue();
  }

  [Fact]
  [SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Testing")]
  public void Equals_Null_IsCorrect()
  {
    StructureValue value = new((string?)null);

    bool result = value.Equals(null);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Equals_Identifier_IsCorrect(string identifier1, string identifier2)
  {
    StructureValue value1 = new(identifier1);
    StructureValue value2 = new(identifier2);

    bool result = value1.Equals(value2);

    result.ShouldBe(identifier1 == identifier2);
  }

  [Theory, RepeatData]
  public void Equals_Text_IsCorrect(string text1, string text2)
  {
    this.SkipIf(text1.IsIdentifier());
    this.SkipIf(text2.IsIdentifier());

    StructureValue value1 = new(text1);
    StructureValue value2 = new(text2);

    bool result = value1.Equals(value2);

    result.ShouldBe(text1 == text2);
  }

  [Theory, RepeatData]
  public void Equals_Tag_IsCorrect(string tag1, string tag2)
  {
    StructureValue value1 = new("a", tag1);
    StructureValue value2 = new("a", tag2);

    bool result = value1.Equals(value2);

    result.ShouldBe(tag1 == tag2);
  }

  [Theory, RepeatData]
  public void Equals_Boolean_IsCorrect(bool check1, bool check2)
  {
    StructureValue value1 = new(check1);
    StructureValue value2 = new(check2);

    bool result = value1.Equals(value2);

    result.ShouldBe(check1 == check2);
  }

  [Theory, RepeatData]
  public void Equals_Number_IsCorrect(decimal number1, decimal number2)
  {
    StructureValue value1 = new(number1);
    StructureValue value2 = new(number2);

    bool result = value1.Equals(value2);

    result.ShouldBe(number1 == number2);
  }

  [Fact]
  public void AsString_Empty_IsCorrect()
  {
    StructureValue value = new((string?)null);

    value.AsString.ShouldBe("");
  }

  [Theory, RepeatData]
  public void AsString_Identifier_IsCorrect(string identifier)
  {
    StructureValue value = new(identifier);

    value.AsString.ShouldBe(identifier);
  }

  [Theory, RepeatData]
  public void AsString_Text_IsCorrect(string text)
  {
    StructureValue value = new(text);

    value.AsString.ShouldBe(text);
  }

  [Theory, RepeatData]
  public void AsString_Boolean_IsCorrect(bool check)
  {
    StructureValue value = new(check);

    value.AsString.ShouldBe(check.TrueFalse());
  }

  [Theory, RepeatData]
  public void AsString_Number_IsCorrect(decimal number)
  {
    StructureValue value = new(number);

    value.AsString.ShouldBe($"{number:0.#####}");
  }

  [Fact]
  public void ToString_Empty_IsCorrect()
  {
    StructureValue value = new((string?)null);

    string result = $"{value}";

    result.ShouldBe("E");
  }

  [Theory, RepeatData]
  public void ToString_Identifier_IsCorrect(string identifier)
  {
    StructureValue value = new(identifier);

    string result = $"{value}";

    result.ShouldBe("I:" + identifier);
  }

  [Theory, RepeatData]
  public void ToString_Text_IsCorrect(string text)
  {
    this.SkipIf(text.IsIdentifier());
    StructureValue value = new(text);

    string result = $"{value}";

    result.ShouldBe("T:" + text);
  }

  [Theory, RepeatData]
  public void ToString_Boolean_IsCorrect(bool check)
  {
    StructureValue value = new(check);

    string result = $"{value}";

    result.ShouldBe("B:" + check.TrueFalse());
  }

  [Theory, RepeatData]
  public void ToString_Number_IsCorrect(decimal number)
  {
    StructureValue value = new(number);

    string result = $"{value}";

    result.ShouldBe($"N:{number:0.#####}");
  }
}
