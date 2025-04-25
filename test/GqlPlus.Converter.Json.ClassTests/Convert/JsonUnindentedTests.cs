namespace GqlPlus.Convert;

public class JsonUnindentedTests
{
  [Theory, RepeatData]
  public void ToJson_WithString_ReturnsCorrect(string input)
  {
    // Arrange
    Structured model = new(input);

    // Act
    string result = model.ToJson(RenderJson.Unindented);

    // Assert
    result.ShouldStartWith(input.Quoted('"'));
  }
}
