namespace GqlPlus.Convert;

public abstract class ValueConvertTestsBase(IConvertTestsBase converters)
  : ValueConvertToTestsBase(converters)
{
  [Fact]
  public void ConvertFrom_Empty()
  {
    string[] input = Expected_Empty();
    IGqlpValue expected = string.IsNullOrWhiteSpace(Tag) ? new GqlpUnit() : new GqlpUnit(Tag);

    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_String(string contents)
  {
    this.SkipIf(contents.ThrowIfNull().Contains('\\', StringComparison.Ordinal));

    string[] input = Expected_String(contents);
    IGqlpValue expected = contents.Encode(Tag);

    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Identifier(string value)
  {
    string[] input = Expected_Identifier(value);
    IGqlpValue expected = value.Encode(Tag);

    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, ClassData<PunctuationData>]
  public void ConvertFrom_Punctuation(string value)
  {
    string[] input = Expected_Punctuation(value);
    IGqlpValue expected = value.Encode(Tag);

    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Decimal(decimal value)
  {
    value = decimal.Round(value, 5); // Ensure precision consistency
    string[] input = Expected_Decimal(value);
    IGqlpValue expected = value.Encode(Tag);

    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Bool(bool value)
  {
    string[] input = Expected_Bool(value);
    IGqlpValue expected = value.Encode(Tag);

    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Fact]
  public void RoundTrip_Empty()
  {
    IGqlpValue expected = string.IsNullOrWhiteSpace(Tag) ? new GqlpUnit() : new GqlpUnit(Tag);

    string[] input = Converters.ConvertTo(expected);
    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_String(string contents)
  {
    this.SkipIf(contents.ThrowIfNull().Contains('\\', StringComparison.Ordinal));

    IGqlpValue expected = contents.Encode(Tag);

    string[] input = Converters.ConvertTo(expected);
    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Identifier(string value)
  {
    IGqlpValue expected = value.Encode(Tag);

    string[] input = Converters.ConvertTo(expected);
    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, ClassData<PunctuationData>]
  public void RoundTrip_Punctuation(string value)
  {
    IGqlpValue expected = value.Encode(Tag);

    string[] input = Converters.ConvertTo(expected);
    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Decimal(decimal value)
  {
    value = decimal.Round(value, 5); // Ensure precision consistency
    IGqlpValue expected = value.Encode(Tag);

    string[] input = Converters.ConvertTo(expected);
    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Bool(bool value)
  {
    IGqlpValue expected = value.Encode(Tag);

    string[] input = Converters.ConvertTo(expected);
    IGqlpValue result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }
}
