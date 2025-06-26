namespace GqlPlus.Modelling.Simple;

public class SimpleModellerTests
  : ModellerClassTestBase<IGqlpFieldKey, SimpleModel>
{
  protected override IModeller<IGqlpFieldKey, SimpleModel> Modeller { get; } = new SimpleModeller();

  [Fact]
  public void ToModel_WithNumber_ReturnsExpectedSimpleModel()
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey(null!);
    ast.Number.Returns(42);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Number.ShouldBe(42);
  }

  [Fact]
  public void ToModel_WithText_ReturnsExpectedSimpleModel()
  {
    // Arrange
    IGqlpFieldKey ast = A.FieldKey("SampleText");

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Text.ShouldBe("SampleText");
  }
}
