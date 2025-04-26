
using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Convert;

public class JsonIndentedTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToJson();

  protected override void WithBoolean_Check(string result, bool input)
    => result.ShouldStartWith($"{input}");
  protected override void WithIdentifier_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));
  protected override void WithListFlow_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithList_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithMapFlow_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{\r\n  \"{key}\": \"{value}\"\r\n}}");
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{\r\n  \"{key}\": \"{value}\"\r\n}}");
  protected override void WithNumber_Check(string result, decimal input)
    => result.ShouldStartWith($"{input}");
  protected override void WithText_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  private string WithTag(string tag, string value, string key = "value")
    => $"{{\r\n  \"$tag\": \"{tag}\",\r\n  \"{key}\": {value}\r\n}}";

  protected override void WithBooleanTag_Check(string result, bool input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithIdentifierTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(WithTag(tag, input.Quoted('"')));
  protected override void WithListTagFlow_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithListTag_Check(string result, string[] input, string tag)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithMapTagFlow_Check(string result, string key, string value, string tag)
    => result.ShouldStartWith(WithTag(tag, value.Quoted('"'), key));
  protected override void WithMapTag_Check(string result, string key, string value, string tag)
    => result.ShouldStartWith(WithTag(tag, value.Quoted('"'), key));
  protected override void WithNumberTag_Check(string result, decimal input, string tag)
    => result.ShouldStartWith(WithTag(tag, $"{input}"));
  protected override void WithTextTag_Check(string result, string input, string tag)
    => result.ShouldStartWith(WithTag(tag, input.Quoted('"')));
}
