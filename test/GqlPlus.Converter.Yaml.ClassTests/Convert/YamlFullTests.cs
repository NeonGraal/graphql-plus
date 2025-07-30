namespace GqlPlus.Convert;

public class YamlFullTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToYaml(wrapped: false);

  protected override IComparer<string> Comparer
    => StringComparer.Ordinal;

  protected override void WithBoolean_Check(string[] result, bool input)
    => result.ShouldBe([input.TrueFalse()]);
  protected override void WithIdentifier_Check(string[] result, string input)
    => result.ShouldBe([input]);
  protected override void WithListFlow_Check(string[] result, string[] input)
    => result.ShouldBe([input.Surround("[", "]", ", ")]);
  protected override void WithList_Check(string[] result, string[] input)
    => result.ShouldBe(input.Select(s => "- " + s));
  protected override void WithListMap_Check(string[] result, string[] input)
    => result.ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapFlow_Check(string[] result, string key, string value)
    => result.ShouldBe([$"{{{key}: {value}}}"]);
  protected override void WithMapKeys_Check(string[] result, string[] keys)
    => result.ShouldBe(["{" + keys.Joined(k => k + ": " + k, ", ") + "}"]);
  protected override void WithMapList_Check(string[] result, string key, string[] value)
    => result.ShouldBe([$"{{{key}: [" + value.Joined(", ") + "]}"]);
  protected override void WithMap_Check(string[] result, string key, string value)
    => result.ShouldBe([$"{key}: {value}"]);
  protected override void WithNull_Check(string[] result)
    => result.ShouldBe([$"--- ''"]);
  protected override void WithNumber_Check(string[] result, decimal input)
    => result.ShouldBe([$"{input}"]);
  protected override void WithText_Check(string[] result, string input)
    => result.ShouldBe([input.Quoted("'")]);

  // Tagged checks
  protected override void WithBooleanTag_Check(string[] result, bool input, string tag)
    => result.ShouldBe(WithTag(tag, input.TrueFalse()));
  protected override void WithIdentifierTag_Check(string[] result, string input, string tag)
    => result.ShouldBe(WithTag(tag, input));
  protected override void WithListTagFlow_Check(string[] result, string[] input, string tag)
    => result.ShouldBe([input.Surround("[", "]", ", ")]);
  protected override void WithListTag_Check(string[] result, string[] input, string tag)
    => result.ShouldBe(input.Select(s => "- " + s));
  protected override void WithListTagMap_Check(string[] result, string[] input, string tag)
    => result.ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapTagFlow_Check(string[] result, string key, string value, string tag)
    => result.ShouldBe(WithTag(tag, $"{{{key}: {value}}}"));
  protected override void WithMapTagKeys_Check(string[] result, string[] keys, string tag)
    => result.ShouldBe([$"!{tag} {{" + keys.Joined(k => k + ": " + k, ", ") + "}"]);
  protected override void WithMapTagList_Check(string[] result, string key, string[] value, string tag)
    => result.ShouldBe([$"!{tag} {{{key}: [" + value.Joined(", ") + "]}"]);
  protected override void WithMapTag_Check(string[] result, string key, string value, string tag)
    => result.ShouldBe([$"!{tag}", $"{key}: {value}"]);
  protected override void WithNullTag_Check(string[] result, string tag)
    => result.ShouldBe([$"--- {tag} ''"]);
  protected override void WithNumberTag_Check(string[] result, decimal input, string tag)
    => result.ShouldBe(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string[] result, string input, string tag)
    => result.ShouldBe([input.Quoted("'")]);

  private static string[] WithTag(string tag, string value)
    => [$"!{tag} {value}"];
}
