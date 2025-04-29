using System.Diagnostics.CodeAnalysis;
using YamlDotNet.Core.Tokens;

namespace GqlPlus.Convert;

public class YamlWrappedTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToYaml(wrapped: true);

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
  protected override void WithMapKeys_Check(string result, string[] keys)
    => result.ToLines().ShouldBe(Wrapped("{", "}", [.. keys.Order(StringComparer.Ordinal)]));
  protected override void WithMapList_Check(string result, string key, string[] value)
    => result.ShouldStartWith($"{{{key}: [" + value.Joined(", ") + "]}");
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{key}: {value}");
  protected override void WithNull_Check(string result)
    => result.ShouldStartWith($"--- ''");
  protected override void WithNumber_Check(string result, decimal input)
    => result.ShouldStartWith($"{input}");
  protected override void WithText_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted("'"));

  // Tagged checks
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
  protected override void WithMapTagKeys_Check(string result, string[] keys, string tag)
    => result.ToLines().ShouldBe(Wrapped($"!{tag} {{", "}", [.. keys.Order(StringComparer.Ordinal)]));
  protected override void WithMapTagList_Check(string result, string key, string[] value, string tag)
    => result.ShouldStartWith($"!{tag} {{{key}: [" + value.Joined(", ") + "]}");
  protected override void WithMapTag_Check(string result, string key, string value, string tag)
    => result.ToLines().ShouldBe([$"!{tag}", $"{key}: {value}"]);
  protected override void WithNullTag_Check(string result, string tag)
    => result.ShouldStartWith($"--- {tag} ''");
  protected override void WithNumberTag_Check(string result, decimal input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(input.Quoted("'"));

  private static string WithTag(string tag, string value)
    => $"!{tag} {value}";

  private static string[] Wrapped(string prefix, string suffix, string[] values)
  {
    List<string> result = [];
    string line = prefix;

    int last = values.Length - 1;
    for (int i = 0; i <= last; i++) {
      line += values[i] + ": " + values[i];
      if (i < last) {
        if (line.Length < RenderYaml.BestWidth) {
          line += ", ";
        } else {
          result.Add(line + ",");
          line = "  ";
        }
      }
    }

    result.Add(line + suffix);

    return [.. result];
  }
}
