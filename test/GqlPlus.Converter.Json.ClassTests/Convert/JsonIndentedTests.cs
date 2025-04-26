
namespace GqlPlus.Convert;

public class JsonIndentedTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToJson();

  protected override void WithList_Check(string result, string[] input)
    => result.ShouldStartWith(input.Surround("[", "]", i => i.Quoted('"'), ", "));
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{{\r\n  \"{key}\": \"{value}\"\r\n}}");
  protected override void WithString_Check(string result, string input)
    => result.ShouldStartWith(input.Quoted('"'));
}
