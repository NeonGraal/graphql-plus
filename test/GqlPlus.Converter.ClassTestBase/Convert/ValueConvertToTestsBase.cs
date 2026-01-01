namespace GqlPlus.Convert;

public abstract class ValueConvertToTestsBase(IConvertTestsBase converters)
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
