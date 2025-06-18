namespace GqlPlus.Generating;

public abstract class TypeGeneratorClassTestBase<T>
  : GeneratorClassTestBase
  where T : class, IGqlpType
{
  public abstract string ExpectedTypePrefix { get; }
  internal abstract GenerateForType<T> TypeGenerator { get; }

  [Fact]
  public void ForType_WithType_ReturnsTrue()
  {
    // Arrange
    T type = A.Error<T>();

    // Act
    bool result = TypeGenerator.ForType(type);

    // Assert
    result.ShouldBeTrue();
  }

  [Fact]
  public void ForType_WithNotType_ReturnsFalse()
  {
    // Arrange
    IGqlpTypeSpecial type = A.Error<IGqlpTypeSpecial>();

    // Act
    bool result = TypeGenerator.ForType(type);

    // Assert
    result.ShouldBeFalse();
  }

  [Fact]
  public void TypePrefix_ReturnsDomain() =>
    TypeGenerator.TypePrefix.ShouldBe(ExpectedTypePrefix);
}
