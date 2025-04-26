namespace GqlPlus.Convert;

public class JsonIndentedTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToJson();

  protected override void WithBoolean_Check(string result, bool input)
    => result.ShouldStartWith($"{input.TrueFalse()}");
  protected override void WithIdentifier_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));
  protected override void WithListFlow_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithList_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListMap_Check(string result, string[] input)
    => result.ToLines().ShouldBe(ListLines(input));
  protected override void WithMapFlow_Check(string result, string key, string value)
                                                                   => result.ToLines().ShouldBe(["{", $"  \"{key}\": \"{value}\"", "}"]);
  protected override void WithMap_Check(string result, string key, string value)
    => result.ToLines().ShouldBe(["{", $"  \"{key}\": \"{value}\"", "}"]);
  protected override void WithNull_Check(string result)
    => result.ShouldBe("");
  protected override void WithNumber_Check(string result, decimal input)
    => result.ShouldStartWith($"{input}");
  protected override void WithText_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));

  // Tagged checks
  protected override void WithBooleanTag_Check(string result, bool input, string tag)
    => result.ToLines().ShouldBe(WithTag(tag, $"{input.TrueFalse()}"));
  protected override void WithIdentifierTag_Check(string result, string input, string tag)
    => result.ToLines().ShouldBe(WithTag(tag, input.Quoted('"')));
  protected override void WithListTagFlow_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListTag_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListTagMap_Check(string result, string[] input, string tag)
    => result.ToLines().ShouldBe(ListLines(input));
  protected override void WithMapTagFlow_Check(string result, string key, string value, string tag)
    => result.ToLines().ShouldBe(WithTag(tag, value.Quoted('"'), key));
  protected override void WithMapTag_Check(string result, string key, string value, string tag)
    => result.ToLines().ShouldBe(WithTag(tag, value.Quoted('"'), key));
  protected override void WithNullTag_Check(string result, string tag)
    => result.ShouldBe("");
  protected override void WithNumberTag_Check(string result, decimal input, string tag)
    => result.ToLines().ShouldBe(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string result, string input, string tag)
    => result.ToLines().ShouldBe(WithTag(tag, input.Quoted('"')));

  private static IEnumerable<string> ListLines(string[]? input)
  {
    if (input is null) {
      return [];
    }

    int lastIndex = input.Length - 1;
    return ["[", .. input.SelectMany(ItemLines), "]"];

    IEnumerable<string> ItemLines(string s, int i)
      => ["  {", "    \"value\": " + s.Quoted('"'), ItemClose(i)];
    string ItemClose(int i)
      => i < lastIndex ? "  }," : "  }";
  }

  private static string[] WithTag(string tag, string value, string key = "value")
    => ["{", $"  \"$tag\": \"{tag}\",", $"  \"{key}\": {value}", "}"];
}
