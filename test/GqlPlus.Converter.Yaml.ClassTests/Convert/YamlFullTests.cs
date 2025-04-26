namespace GqlPlus.Convert;

public class YamlFullTests
  : ConverterClassTestBase
{
  protected override string Convert(Structured model)
    => model.ToYaml(wrapped: false);

  protected override void WithList_Check(string result, string[] input)
    => result.ShouldStartWith(input.Joined(s => "- " + s, Environment.NewLine));
  protected override void WithMap_Check(string result, string key, string value)
    => result.ShouldStartWith($"{key}: {value}");
  protected override void WithString_Check(string result, string input)
    => result.ShouldStartWith(input);
}
