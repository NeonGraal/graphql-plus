namespace GqlPlus.Modelling.Simple;

public class SimpleModellerTests
  : ModellerClassTestBase<IGqlpFieldKey, SimpleModel>
{
  protected override IModeller<IGqlpFieldKey, SimpleModel> Modeller { get; } = new SimpleModeller();

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void ToModel_WithNothing_ReturnsExpectedSimpleModel(string? value)
  {
    // Arrange
    IGqlpFieldKey ast = A.Error<IGqlpFieldKey>();
    ast.Text.Returns(value);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .IsEmpty.ShouldBe(true);
  }

  [Theory]
  [InlineData("Boolean", "true", true)]
  [InlineData("boolean", "False", false)]
  [InlineData("BOOLEAN", "tRUe", true)]
  [InlineData("BooLEan", "FALSE", false)]
  public void ToModel_WithBoolean_ReturnsExpectedSimpleModel(string type, string label, bool expected)
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(null!);
    ast.EnumType.Returns(type);
    ast.EnumLabel.Returns(label);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Boolean.ShouldBe(expected);
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
