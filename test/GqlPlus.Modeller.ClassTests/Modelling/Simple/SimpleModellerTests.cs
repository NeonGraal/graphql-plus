namespace GqlPlus.Modelling.Simple;

public class SimpleModellerTests
  : ModellerClassTestBase<IGqlpFieldKey, SimpleModel>
{
  protected override IModeller<IGqlpFieldKey, SimpleModel> Modeller { get; } = new SimpleModeller();

  [Fact]
  public void ToModel_WithNothing_ReturnsExpectedSimpleModel()
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(null!);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .IsEmpty.ShouldBe(true);
  }

  [Fact]
  public void ToModel_WithBoolean_ReturnsExpectedSimpleModel()
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(null!);
    ast.EnumType.Returns("Boolean");
    ast.EnumLabel.Returns("true");

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Boolean.ShouldBe(true);
  }

  [Theory, RepeatData]
  public void ToModel_WithEnum_ReturnsExpectedSimpleModel(string enumType, string enumLabel)
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(null!);
    ast.EnumType.Returns(enumType);
    ast.EnumLabel.Returns(enumLabel);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .EnumValue.ShouldBe($"{enumType}.{enumLabel}");
  }

  [Theory, RepeatData]
  public void ToModel_WithNumber_ReturnsExpectedSimpleModel(decimal value)
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(null!);
    ast.Number.Returns(value);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Number.ShouldBe(value);
  }

  [Theory, RepeatData]
  public void ToModel_WithText_ReturnsExpectedSimpleModel(string value)
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(value);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Text.ShouldBe(value);
  }
}
