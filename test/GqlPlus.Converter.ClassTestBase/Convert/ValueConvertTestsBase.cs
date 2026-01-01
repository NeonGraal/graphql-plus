namespace GqlPlus.Convert;

public abstract class ValueConvertTestsBase(IConvertTestsBase converters)
  : ValueConvertToTestsBase(converters)
{
  [Fact]
  public void ConvertFrom_Empty()
  {
    string[] input = Expected_Empty();
    Structured expected = new("", Tag);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_String(string contents)
  {
    this.SkipIf(contents.ThrowIfNull().Contains('\\', StringComparison.Ordinal));

    string[] input = Expected_String(contents);
    Structured expected = new(new(contents, Tag));

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Identifier(string value)
  {
    string[] input = Expected_Identifier(value);
    Structured expected = new(value, Tag);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, ClassData<PunctuationData>]
  public void ConvertFrom_Punctuation(string value)
  {
    string[] input = Expected_Punctuation(value);
    Structured expected = new(value, Tag);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Decimal(decimal value)
  {
    value = decimal.Round(value, 5); // Ensure precision consistency
    string[] input = Expected_Decimal(value);
    Structured expected = new(value, Tag);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Bool(bool value)
  {
    string[] input = Expected_Bool(value);
    Structured expected = new(value, Tag);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Fact]
  public void RoundTrip_Empty()
  {
    Structured expected = new("", Tag);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_String(string contents)
  {
    this.SkipIf(contents.ThrowIfNull().Contains('\\', StringComparison.Ordinal));

    Structured expected = new(new(contents, Tag));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Identifier(string value)
  {
    Structured expected = new(value, Tag);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, ClassData<PunctuationData>]
  public void RoundTrip_Punctuation(string value)
  {
    Structured expected = new(value, Tag);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Decimal(decimal value)
  {
    value = decimal.Round(value, 5); // Ensure precision consistency
    Structured expected = new(value, Tag);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Bool(bool value)
  {
    Structured expected = new(value, Tag);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }
}
