﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Convert;

public class JsonUnindentedTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToJson(RenderJson.Unindented);

  protected override void WithBoolean_Check(string result, bool input)
    => result.ShouldStartWith($"{input}");
  protected override void WithIdentifier_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));
  protected override void WithListFlow_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithList_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListMap_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => $"{{\"value\":\"{i}\"}}", ","));
  protected override void WithMapFlow_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{\"{key}\":\"{value}\"}}");
  protected override void WithMapKeys_Check(string result, string[] keys)
    => result.ShouldStartWith("{" + keys.Order(StringComparer.CurrentCultureIgnoreCase).Select(k => $"\"{k}\":\"{k}\"").Joined(",") + "}");
  protected override void WithMapList_Check(string result, string key, string[] value)
    => result.ShouldStartWith($"{{\"{key}\":" + value.Surround("[", "]", i => i.Quoted('"'), ", ") + "}");
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{\"{key}\":\"{value}\"}}");
  protected override void WithNull_Check(string result)
    => result.ShouldBe("");
  protected override void WithNumber_Check(string result, decimal input)
    => result.ShouldStartWith($"{input}");
  protected override void WithText_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));

  // Tagged checks
  protected override void WithBooleanTag_Check(string result, bool input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithIdentifierTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(WithTag(tag, input.Quoted('"')));
  protected override void WithListTagFlow_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListTag_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListTagMap_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => $"{{\"value\":\"{i}\"}}", ","));
  protected override void WithMapTagFlow_Check(string result, string key, string value, string tag)
    => result.ShouldStartWith(WithTag(tag, value.Quoted('"'), key));
  protected override void WithMapTagKeys_Check(string result, [NotNull] string[] keys, string tag)
    => result.ShouldStartWith($"{{\"$tag\":\"{tag}\"," + keys.Order(StringComparer.CurrentCultureIgnoreCase).Select(k => $"\"{k}\":\"{k}\"").Joined(",") + "}");
  protected override void WithMapTagList_Check(string result, string key, string[] value, string tag)
    => result.ShouldStartWith($"{{\"$tag\":\"{tag}\",\"{key}\":" + value.Surround("[", "]", i => i.Quoted('"'), ", ") + "}");
  protected override void WithMapTag_Check(string result, string key, string value, string tag)
    => result.ShouldStartWith(WithTag(tag, value.Quoted('"'), key));
  protected override void WithNullTag_Check(string result, string tag)
    => result.ShouldBe("");
  protected override void WithNumberTag_Check(string result, decimal input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(WithTag(tag, input.Quoted('"')));

  private static string WithTag(string tag, string value, string key = "value")
    => $"{{\"$tag\":\"{tag}\",\"{key}\":{value}}}";
}
