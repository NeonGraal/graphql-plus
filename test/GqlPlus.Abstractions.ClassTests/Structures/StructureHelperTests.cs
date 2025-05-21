using System.Diagnostics.CodeAnalysis;
using GqlPlus.Token;

namespace GqlPlus.Structures;

public class StructureHelperTests
{
  [Theory, RepeatData]
  public void Render_Errors_ReturnsCorrect([NotNull] string[] messages)
  {
    // Arrange
    TokenAt at = new(TokenKind.Identifer, 1, 1, "id");
    ITokenMessages errors = new TokenMessages([.. messages.Select(m => new TokenMessage(at, m))]);

    // Act
    Structured result = errors.Render();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBe("_Errors"),
      r => r.Flow.ShouldBe(false),
      r => r.List.Count.ShouldBe(messages.Length)
    );
  }

  [Theory, RepeatData]
  public void RenderEnum_ReturnsCorrect([NotNull] TokenKind value)
  {
    //Arrange
    string typeTag = typeof(TokenKind).TypeTag();

    // Act
    Structured result = value.RenderEnum();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBe(typeTag),
      r => r.Value!.AsString.ShouldBe(value.ToString())
    );
  }

  [Fact]
  public void TypeTag_Generic_ReturnsCorrect()
  {
    Type type = typeof(Map<string>);

    string result = type.TypeTag();

    result.ShouldBe("_Map(_String)");
  }
}
