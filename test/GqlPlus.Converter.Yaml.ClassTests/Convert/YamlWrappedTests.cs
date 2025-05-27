using System.Diagnostics.CodeAnalysis;
using Xunit;
using YamlDotNet.Core.Tokens;

namespace GqlPlus.Convert;

public class YamlWrappedTests
  : ConverterClassTestBase
{
  [Fact]
  public void WithListFlowSpecific_ReturnsCorrect()
  {
    // Arrange
    string[] input = ["L__8OEl_G", "G_7_x___j4GK1___8PVI", "CB83yzlk__41rUr3FU_", "mK33H_", "r3OO"];
    Structured model = input.Render(flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithListFlow_Check(result, input);
  }

  [Fact]
  public void WithListTagFlowSpecific_ReturnsCorrect()
  {
    // Arrange
    string[] input = ["q04_9_1_84t3UnnF", "fR", "G2", "htgbTjj_57_wBW5qz25_C_rC347V17c_e8", "MP"];
    string tag = "WvZsK2_";
    Structured model = input.Render(tag, flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithListTagFlow_Check(result, input, tag);
  }

  protected override string Convert(Structured model)
    => model.ToYaml(wrapped: true);

  protected override void WithBoolean_Check(string result, bool input)
    => result.ShouldStartWith($"{input}");
  protected override void WithIdentifier_Check(string result, string input)
    => result.ShouldStartWith(input);
  protected override void WithListFlow_Check(string result, [NotNull] string[] input)
    => result.ToLines().ShouldBe(Wrapped("[", "]", input, k => k, "  "));
  protected override void WithList_Check(string result, string[] input)
    => result.ToLines().ShouldBe(input.Select(s => "- " + s));
  protected override void WithListMap_Check(string result, string[] input)
    => result.ToLines().ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapFlow_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{{key}: {value}}}");
  protected override void WithMapKeys_Check(string result, string[] keys)
    => result.ToLines().ShouldBe(Wrapped("{", "}", [.. keys.Order(StringComparer.Ordinal)], k => k + ": " + k, "  "));
  protected override void WithMapList_Check(string result, string key, [NotNull] string[] value)
    => result.ToLines().ShouldBe(Wrapped($"{{{key}: [", "]}", value, k => k, "    "));
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{key}: {value}");
  protected override void WithNull_Check(string result)
    => result.ShouldStartWith($"--- ''");
  protected override void WithNumber_Check(string result, decimal input)
    => result.ShouldStartWith($"{input}");
  protected override void WithText_Check(string result, [NotNull] string input)
    => result.ToLines().ShouldBe(input.Length > RenderYaml.BestWidth / 2 ? [">-", "  " + input] : [input.Quoted("'")]);

  // Tagged checks
  protected override void WithBooleanTag_Check(string result, bool input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithIdentifierTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(WithTag(tag, input));
  protected override void WithListTagFlow_Check(string result, [NotNull] string[] input, string tag)
    => result.ToLines().ShouldBe(Wrapped("[", "]", input, k => k, "  "));
  protected override void WithListTag_Check(string result, string[] input, string tag)
    => result.ToLines().ShouldBe(input.Select(s => "- " + s));
  protected override void WithListTagMap_Check(string result, string[] input, string tag)
    => result.ToLines().ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapTagFlow_Check(string result, string key, string value, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{{{key}: {value}}}"));
  protected override void WithMapTagKeys_Check(string result, string[] keys, string tag)
    => result.ToLines().ShouldBe(Wrapped($"!{tag} {{", "}", [.. keys.Order(StringComparer.Ordinal)], k => k + ": " + k, "  "));
  protected override void WithMapTagList_Check(string result, string key, [NotNull] string[] value, string tag)
    => result.ToLines().ShouldBe(Wrapped($"!{tag} {{{key}: [", "]}", value, k => k, "    "));
  protected override void WithMapTag_Check(string result, string key, string value, string tag)
    => result.ToLines().ShouldBe([$"!{tag}", $"{key}: {value}"]);
  protected override void WithNullTag_Check(string result, string tag)
    => result.ShouldStartWith($"--- {tag} ''");
  protected override void WithNumberTag_Check(string result, decimal input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string result, [NotNull] string input, string tag)
    => result.ToLines().ShouldBe(input.Length > RenderYaml.BestWidth / 2 ? [">-", "  " + input] : [input.Quoted("'")]);

  private static string WithTag(string tag, string value)
    => $"!{tag} {value}";

  private static string[] Wrapped(string prefix, string suffix, string[] values, Func<string, string> mapper, string indent)
  {
    List<string> result = [];
    string line = prefix;
    int last = values.Length - 1;
    for (int i = 0; i <= last; i++) {
      line += mapper(values[i]);
      if (i < last) {
        if (line.Length < RenderYaml.BestWidth) {
          line += ", ";
        } else {
          result.Add(line + ",");
          line = indent;
        }
      }
    }

    result.Add(line + suffix);

    return [.. result];
  }
}
