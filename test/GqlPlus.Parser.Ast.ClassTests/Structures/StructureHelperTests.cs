using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Token;

namespace GqlPlus.Structures;

public class StructureHelperTests
{
  [Theory, RepeatData]
  public void Encode_Text_IsCorrect(string value)
  {
    // Act
    Structured result = value.Encode();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBeEmpty(),
      r => r.Value!.Text.ShouldBe(value)
    );
  }

  [Theory, RepeatData]
  public void Encode_Boolean_IsCorrect(bool value)
  {
    // Act
    Structured result = value.Encode();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBeEmpty(),
      r => r.Value!.Boolean.ShouldBe(value)
    );
  }

  [Theory, RepeatData]
  public void Encode_Int_IsCorrect(int value)
  {
    // Act
    Structured result = value.Encode();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBeEmpty(),
      r => r.Value!.Number.ShouldBe(value)
    );
  }

  [Theory, RepeatData]
  public void Encode_Number_IsCorrect(decimal value)
  {
    // Act
    Structured result = value.Encode();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBeEmpty(),
      r => r.Value!.Number.ShouldBe(value)
    );
  }

  [Fact]
  public void Encode_NullBoolean_IsCorrect()
  {
    // Arrange
    bool? value = null;

    // Act
    Structured? result = value.Encode();

    // Assert
    result.ShouldBeNull();
  }

  [Fact]
  public void Encode_NullInt_IsCorrect()
  {
    // Arrange
    int? value = null;

    // Act
    Structured? result = value.Encode();

    // Assert
    result.ShouldBeNull();
  }

  [Fact]
  public void Encode_NullNumber_IsCorrect()
  {
    // Arrange
    decimal? value = null;

    // Act
    Structured? result = value.Encode();

    // Assert
    result.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void Encode_Errors_ReturnsCorrect([NotNull] string[] messages)
  {
    // Arrange
    TokenAt at = new(TokenKind.Identifer, 1, 1, "id");
    IMessages errors = new Messages([.. messages.Select(m => new TokenMessage(at, m))]);

    // Act
    Structured result = errors.Encode();

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.Tag.ShouldBe("_Errors"),
      r => r.Flow.ShouldBe(false),
      r => r.List.Count.ShouldBe(messages.Length)
    );
  }

  [Theory, RepeatData]
  public void EncodeEnum_ReturnsCorrect([NotNull] TokenKind value)
  {
    //Arrange
    string typeTag = typeof(TokenKind).TypeTag();

    // Act
    Structured result = value.EncodeEnum();

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
