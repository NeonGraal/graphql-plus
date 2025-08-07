using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace GqlPlus.Convert;

public class YamlWrappedTests
  : ConverterClassTestBase
{
  [Fact]
  public void WithListFlowSpecific_ReturnsCorrect()
  {
    // Arrange
    string[] input = ["L__8OEl_G", "G_7_x___j4GK1___8PVI", "CB83yzlk__41rUr3FU_", "mK33H_", "r3OO"];

    WithListFlow_ReturnsCorrect(input);
  }

  [Fact]
  public void WithListTagFlowSpecific_ReturnsCorrect()
  {
    // Arrange
    string[] input = ["q04_9_1_84t3UnnF", "fR", "G2", "htgbTjj_57_wBW5qz25_C_rC347V17c_e8", "MP"];
    string tag = "WvZsK2_";

    WithListTagFlow_ReturnsCorrect(input, tag);
  }

  [Theory]
  [InlineData("aWlSP6nd9e82fS561t_6zz8Od18c_tsA68GH_3", new string[] { "d1V80", "Fm5s4" }, "a_WF4s3N1ZRDk6_t_2")]
  [InlineData("yh91_y__", new string[] { "B_8p_2_k5_9zR_H73_", "O_H_wFq", "W____CR_Tm", "Fz9hiMpL2q_F" }, "JYE91__")]
  public void WithMapTagListSpecific_ReturnsCorrect(string key, string[] value, string tag)
    => WithMapTagList_ReturnsCorrect(key, value, tag);

  protected override string Convert(Structured model)
    => model.ToYaml(wrapped: true);

  protected override IComparer<string> Comparer
    => StringComparer.Ordinal;

  protected override void WithBoolean_Check(string[] result, bool input)
    => result.ShouldBe([input.TrueFalse()]);
  protected override void WithIdentifier_Check(string[] result, string input)
    => result.ShouldBe([input]);
  protected override void WithListFlow_Check(string[] result, [NotNull] string[] input)
    => result.ShouldBe(Wrapped("[", "]", input));
  protected override void WithList_Check(string[] result, string[] input)
    => result.ShouldBe(input.Select(s => "- " + s));
  protected override void WithListMap_Check(string[] result, string[] input)
    => result.ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapFlow_Check(string[] result, string key, string value)
    => result.ShouldBe([$"{{{key}: {value}}}"]);
  protected override void WithMapKeys_Check(string[] result, string[] keys)
    => result.ShouldBe(Wrapped("{", "}", keys.ThrowIfNull(), k => k + ": " + k));
  protected override void WithMapList_Check(string[] result, string key, [NotNull] string[] value)
    => result.ShouldBe(Wrapped($"{{{key}: [", "]}", value, "    "));
  protected override void WithMap_Check(string[] result, string key, string value)
    => result.ShouldBe([$"{key}: {value}"]);
  protected override void WithNull_Check(string[] result)
    => result.ShouldBe([$"--- ''"]);
  protected override void WithNumber_Check(string[] result, decimal input)
    => result.ShouldBe([$"{input}"]);
  protected override void WithText_Check(string[] result, [NotNull] string input)
    => result.ShouldBe(input.Length > RenderYaml.BestWidth / 2 ? [">-", "  " + input] : [input.Quoted("'")]);

  // Tagged checks
  protected override void WithBooleanTag_Check(string[] result, bool input, string tag)
    => result.ShouldBe(WithTag(tag, input.TrueFalse()));
  protected override void WithIdentifierTag_Check(string[] result, string input, string tag)
    => result.ShouldBe(WithTag(tag, input));
  protected override void WithListTagFlow_Check(string[] result, [NotNull] string[] input, string tag)
    => result.ShouldBe(Wrapped("[", "]", input));
  protected override void WithListTag_Check(string[] result, string[] input, string tag)
    => result.ShouldBe(input.Select(s => "- " + s));
  protected override void WithListTagMap_Check(string[] result, string[] input, string tag)
    => result.ShouldBe(input.Select(s => "- value: " + s));
  protected override void WithMapTagFlow_Check(string[] result, string key, string value, string tag)
    => result.ShouldBe(WithTag(tag, $"{{{key}: {value}}}"));
  protected override void WithMapTagKeys_Check(string[] result, string[] keys, string tag)
    => result.ShouldBe(Wrapped($"!{tag} {{", "}", keys.ThrowIfNull(), k => k + ": " + k));
  protected override void WithMapTagList_Check(string[] result, string key, [NotNull] string[] value, string tag)
    => result.ShouldBe(Wrapped($"!{tag} {{{key}: [", "]}", value, "    "));
  protected override void WithMapTag_Check(string[] result, string key, string value, string tag)
    => result.ShouldBe([$"!{tag}", $"{key}: {value}"]);
  protected override void WithNullTag_Check(string[] result, string tag)
    => result.ShouldBe([$"--- {tag} ''"]);
  protected override void WithNumberTag_Check(string[] result, decimal input, string tag)
    => result.ShouldBe(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string[] result, [NotNull] string input, string tag)
    => result.ShouldBe(input.Length > RenderYaml.BestWidth / 2 ? [">-", "  " + input] : [input.Quoted("'")]);

  private static string[] WithTag(string tag, string value)
    => [$"!{tag} {value}"];

  private static string[] Wrapped(string prefix, string suffix, string[] values, string indent)
    => Wrapped(prefix, suffix, values, null, indent);
  private static string[] Wrapped(string prefix, string suffix, string[] values, Func<string, string>? mapper = null, string indent = "  ")
  {
    List<string> result = [];
    string line = prefix;
    if (line.Length >= RenderYaml.BestWidth) {
      result.Add(line);
      line = indent;
    }

    int last = values.Length - 1;
    for (int i = 0; i <= last; i++) {
      line += mapper?.Invoke(values[i]) ?? values[i];

      if (i < last) {
        if (line.Length >= RenderYaml.BestWidth) {
          result.Add(line + ",");
          line = indent;
        } else {
          line += ", ";
        }
      }
    }

    result.Add(line + suffix);

    return [.. result];
  }
}
