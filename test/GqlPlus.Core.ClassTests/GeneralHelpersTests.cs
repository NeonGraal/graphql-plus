namespace GqlPlus;

public class GeneralHelpersTests
{
  [Theory, RepeatData]
  public void GetValueOr_Missing_ReturnDefault(string key)
  {
    Map<string> map = [];

    string result = map.GetValueOr(key, key);

    result.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void GetValueOr_PresentWithValue_ReturnValue(string key)
  {
    Map<string> map = [key.ToKeyValue(key)];

    string result = map.GetValueOr(key, "error");

    result.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void GetValueOr_Missing_ReturnDefaultFunction(string key)
  {
    Map<string> map = [];

    string result = map.GetValueOr(key, k => k);

    result.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void GetValueOr_PresentWithFunction_ReturnValue(string key)
  {
    Map<string> map = [key.ToKeyValue(key)];

    string result = map.GetValueOr(key, k => "error");

    result.ShouldBe(key);
  }

  [Fact]
  public void ThrowIfNull_NullValue_ThrowsArgumentNullException()
  {
    string? input = null;

    Action result = () => input.ThrowIfNull();

    result.ShouldThrow<ArgumentNullException>()
      .ParamName.ShouldBe(nameof(input));
  }

  [Theory, RepeatData]
  public void Prefixed_NullInput_ReturnsEmptyString(string prefix)
  {
    string? input = null;

    string result = input.Prefixed(prefix);

    result.ShouldBe(string.Empty);
  }

  [Theory, RepeatData]
  public void Suffixed_NullInput_ReturnsEmptyString(string suffix)
  {
    string? input = null;

    string result = input.Suffixed(suffix);

    result.ShouldBe(string.Empty);
  }

  [Fact]
  public void Quoted_NullInput_ReturnsEmptyString()
  {
    string? input = null;

    string result = input.Quoted('"');

    result.ShouldBe(string.Empty);
  }
}
