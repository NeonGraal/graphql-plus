namespace GqlPlus.Convert;

public abstract class ConverterClassTestBase
{
  [Theory, RepeatData]
  public void WithString_ReturnsCorrect(string input)
  {
    // Arrange
    Structured model = new(input);

    // Act
    string result = Convert(model);

    // Assert
    WithString_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithList_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Render();

    // Act
    string result = Convert(model);

    // Assert
    WithList_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithMap_ReturnsCorrect(string key, string value)
  {
    // Arrange
    Map<string> map = new() { [key] = value };
    Structured model = map.Render(s => new(s));

    // Act
    string result = Convert(model);

    // Assert
    WithMap_Check(result, key, value);
  }

  protected abstract string Convert(Structured model);

  protected abstract void WithString_Check(string result, string input);
  protected abstract void WithList_Check(string result, string[] input);
  protected abstract void WithMap_Check(string result, string key, string value);
}
