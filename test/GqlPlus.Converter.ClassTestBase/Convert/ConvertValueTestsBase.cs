namespace GqlPlus.Convert;

public abstract class ConvertValueTestsBase(IConvertTestsBase converters)
  : ConvertTestsBase(converters)
{
  protected string Tag { get; set; } = "";
  protected abstract string[] Expected_Empty();
  protected abstract string[] Expected_String(string value);
  protected abstract string[] Expected_Identifier(string value);
  protected abstract string[] Expected_Punctuation(string value);
  protected abstract string[] Expected_Decimal(decimal value);
  protected abstract string[] Expected_Bool(bool value);

  [Fact]
  public void ConvertTo_Empty()
  {
    Structured model = new("", Tag);
    string[] expected = Expected_Empty();

    string[] result = Converters.ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_String(string value) // Should be contents
  {
    this.SkipIf(value.ThrowIfNull().Contains('\\', StringComparison.Ordinal));

    string[] expected = Expected_String(value);
    Structured model = new(new(value, Tag));

    string[] result = Converters.ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_Identifier(string value)
  {
    string[] expected = Expected_Identifier(value);
    Structured model = new(value, Tag);

    string[] result = Converters.ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, ClassData<PunctuationData>]
  public void ConvertTo_Punctuation(string value)
  {
    string[] expected = Expected_Punctuation(value);
    Structured model = new(value, Tag);

    string[] result = Converters.ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_Decimal(decimal value)
  {
    string[] expected = Expected_Decimal(value);
    Structured model = new(value, Tag);

    string[] result = Converters.ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_Bool(bool value)
  {
    string[] expected = Expected_Bool(value);
    Structured model = new(value, Tag);

    string[] result = Converters.ConvertTo(model);

    result.ShouldBe(expected);
  }

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

public class PunctuationData : TheoryData<string>
{
  public PunctuationData()
  {
    Add("{");
    Add("}");
    Add("[");
    Add("]");
    //Add("&");
    Add("#");
    Add("*");
    Add("?");
    Add("|");
    Add("-");
    //Add("<");
    //Add(">");
    //Add("=");
    Add("!");
    Add("%");
    Add("@");
    Add(":");
    //Add("`");
    Add(",");
  }
}
