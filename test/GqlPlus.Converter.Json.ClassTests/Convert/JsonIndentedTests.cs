using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace GqlPlus.Convert;

public class JsonIndentedTests
  : ConverterClassTestBase
{
  [Fact]
  public void WithMapKeysSpecific_ReturnsCorrect()
  {
    string[] keys = ["L6", "K", "twE39__243f", "k"];

    WithMapKeys_ReturnsCorrect(keys);
  }

  [Fact]
  public void WithMapTagKeysSpecific_ReturnsCorrect()
  {
    string[] keys = ["X", "E_7__6_Y_", "x", "HfVh_", "rM_f"];
    string tag = "m";

    WithMapTagKeys_ReturnsCorrect(keys, tag);
  }

  protected override string Convert(Structured model)
    => model.ToJson();

  protected override IComparer<string> Comparer
    => StringComparer.CurrentCultureIgnoreCase;

  protected override void WithBoolean_Check(string[] result, bool input)
    => result.ShouldBe([input.TrueFalse()]);
  protected override void WithIdentifier_Check(string[] result, string input)
    => result.ShouldBe([input.Quoted('"')]);
  protected override void WithListFlow_Check(string[] result, string[] input)
    => result.ShouldBe([input.Surround("[", "]", i => i.Quoted('"'), ", ")]);
  protected override void WithList_Check(string[] result, string[] input)
    => result.ShouldBe([input.Surround("[", "]", i => i.Quoted('"'), ", ")]);
  protected override void WithListMap_Check(string[] result, string[] input)
    => result.ShouldBe(ListLines("[", "]", input, s => "    \"value\": " + s.Quoted('"')));
  protected override void WithMapFlow_Check(string[] result, string key, string value)
    => result.ShouldBe(["{", $"  \"{key}\": \"{value}\"", "}"]);
  protected override void WithMapKeys_Check(string[] result, [NotNull] string[] keys)
    => result.ShouldBe(["{", .. keys.Select(MapKeysFormat(keys.Length - 1)), "}"], Case.Insensitive);
  protected override void WithMapList_Check(string[] result, string key, string[] value)
    => result.ShouldBe(["{", $"  \"{key}\": " + value.Surround("[", "]", s => s.Quoted('"'), ", "), "}"]);
  protected override void WithMap_Check(string[] result, string key, string value)
    => result.ShouldBe(["{", $"  \"{key}\": \"{value}\"", "}"]);
  protected override void WithNull_Check(string[] result)
    => result.ShouldBeEmpty();
  protected override void WithNumber_Check(string[] result, decimal input)
    => result.ShouldBe([$"{input}"]);
  protected override void WithText_Check(string[] result, string input)
    => result.ShouldBe([input.Quoted('"')]);

  // Tagged checks
  protected override void WithBooleanTag_Check(string[] result, bool input, string tag)
    => result.ShouldBe(WithTag(tag, input.TrueFalse()));
  protected override void WithIdentifierTag_Check(string[] result, string input, string tag)
    => result.ShouldBe(WithTag(tag, input.Quoted('"')));
  protected override void WithListTagFlow_Check(string[] result, string[] input, string tag)
    => result.ShouldBe([input.Surround("[", "]", i => i.Quoted('"'), ", ")]);
  protected override void WithListTag_Check(string[] result, string[] input, string tag)
    => result.ShouldBe([input.Surround("[", "]", i => i.Quoted('"'), ", ")]);
  protected override void WithListTagMap_Check(string[] result, string[] input, string tag)
    => result.ShouldBe(ListLines("[", "]", input, s => "    \"value\": " + s.Quoted('"')));
  protected override void WithMapTagFlow_Check(string[] result, string key, string value, string tag)
    => result.ShouldBe(WithTag(tag, value.Quoted('"'), key));
  protected override void WithMapTagKeys_Check(string[] result, [NotNull] string[] keys, string tag)
    => result.ShouldBe(["{", $"  \"$tag\": \"{tag}\",", .. keys.Select(MapKeysFormat(keys.Length - 1)), "}"], Case.Insensitive);
  protected override void WithMapTagList_Check(string[] result, string key, string[] value, string tag)
    => result.ShouldBe(["{", $"  \"$tag\": \"{tag}\",", $"  \"{key}\": " + value.Surround("[", "]", s => s.Quoted('"'), ", "), "}"]);
  protected override void WithMapTag_Check(string[] result, string key, string value, string tag)
    => result.ShouldBe(WithTag(tag, value.Quoted('"'), key));
  protected override void WithNullTag_Check(string[] result, string tag)
    => result.ShouldBeEmpty();
  protected override void WithNumberTag_Check(string[] result, decimal input, string tag)
    => result.ShouldBe(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string[] result, string input, string tag)
    => result.ShouldBe(WithTag(tag, input.Quoted('"')));

  private static IEnumerable<string> ListLines(string before, string after, string[]? input, Func<string, string> mapper, string? tag = null)
  {
    if (input is null) {
      return [];
    }

    Func<int, string> itemClose = MakeClose(input.Length - 1, "  }");
    string[] tags = [$"  \"$tag\": \"{tag}\","];
    if (string.IsNullOrWhiteSpace(tag)) {
      tags = [];
    }

    return [before, .. tags, .. input.SelectMany(ItemLines), after];

    IEnumerable<string> ItemLines(string s, int i)
      => ["  {", mapper(s), itemClose(i)];
  }

  private static Func<int, string> MakeClose(int lastIndex, string close)
    => i => i < lastIndex ? close + "," : close;

  private static Func<string, int, string> MapKeysFormat(int lastIndex)
    => (k, i) => $"  \"{k}\": \"{k}\"" + (i < lastIndex ? "," : string.Empty);

  private static string[] WithTag(string tag, string value, string key = "value")
    => ["{", $"  \"$tag\": \"{tag}\",", $"  \"{key}\": {value}", "}"];
}
