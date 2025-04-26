using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Convert;

public class YamlFullTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToYaml(wrapped: false);

  protected override void WithBoolean_Check(string result, bool input)
    => result.ShouldStartWith($"{input}");
  protected override void WithIdentifier_Check(string result, string input)
    => result.ShouldStartWith(input);
  protected override void WithListFlow_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", ", "));
  protected override void WithList_Check(string result, string[] input)
    => result.ToLines().ShouldBe(input.Select(s => "- " + s));
  protected override void WithListMap_Check(string result, string[] input)
    => result.ToLines().ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapFlow_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{{key}: {value}}}");
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{key}: {value}");
  protected override void WithNull_Check(string result)
    => result.ShouldStartWith($"--- ''");
  protected override void WithNumber_Check(string result, decimal input)
    => result.ShouldStartWith($"{input}");
  protected override void WithText_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted("'"));

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  private string WithTag(string tag, string value)
    => $"!{tag} {value}";

  protected override void WithBooleanTag_Check(string result, bool input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithIdentifierTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(WithTag(tag, input));
  protected override void WithListTagFlow_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", ", "));
  protected override void WithListTag_Check(string result, string[] input, string tag)
    => result.ToLines().ShouldBe(input.Select(s => "- " + s));
  protected override void WithListTagMap_Check(string result, string[] input, string tag)
    => result.ToLines().ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapTagFlow_Check(string result, string key, string value, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{{{key}: {value}}}"));
  protected override void WithMapTag_Check(string result, string key, string value, string tag)
    => result.ToLines().ShouldBe([$"!{tag}", $"{key}: {value}"]);
  protected override void WithNullTag_Check(string result, string tag)
    => result.ShouldStartWith($"--- {tag} ''");
  protected override void WithNumberTag_Check(string result, decimal input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(input.Quoted("'"));
}
