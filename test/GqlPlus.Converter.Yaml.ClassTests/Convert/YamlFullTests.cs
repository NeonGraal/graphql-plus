namespace GqlPlus.Convert;

public class YamlFullTests
{
  [Theory, RepeatData]
  public void ToYaml_WithString_ReturnsCorrect(string input)
  {
    // Arrange
    Structured model = new(input);

    // Act
    string result = model.ToYaml(wrapped: false);

    // Assert
    result.ShouldStartWith(input);
  }
}
