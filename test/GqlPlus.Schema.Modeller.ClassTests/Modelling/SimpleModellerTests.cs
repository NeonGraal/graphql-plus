using GqlPlus.Ast;

namespace GqlPlus.Modelling;

public class SimpleModellerTests
  : ModellerClassTestBase<IAstFieldKey, SimpleModel>
{
  private readonly IModeller<IAstEnumValue, EnumValueModel> _enumValueModeller;

  protected override IModeller<IAstFieldKey, SimpleModel> Modeller { get; }

  public SimpleModellerTests()
  {
    _enumValueModeller = MFor<IAstEnumValue, EnumValueModel>();
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstEnumValue, EnumValueModel>().Returns(_enumValueModeller);
    Modeller = new SimpleModeller(modellers);
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void ToModel_WithNothing_ReturnsExpectedSimpleModel(string? value)
  {
    // Arrange
    IAstFieldKey ast = A.Error<IAstFieldKey>();
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
    IAstFieldKey ast = A.EnumFieldKey(type, label);

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
    IAstFieldKey ast = A.EnumFieldKey(enumType, enumLabel);
    EnumValueModel expected = new(enumType, enumLabel, "");
    _enumValueModeller.ToModel(Arg.Any<IAstEnumValue>(), TypeKinds)
        .Returns(expected);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .EnumValue.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToModel_WithNumber_ReturnsExpectedSimpleModel(decimal value)
  {
    // Arrange
    IAstFieldKey ast = A.FieldKey(null!);
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
    IAstFieldKey ast = A.FieldKey(value);

    // Act
    SimpleModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Text.ShouldBe(value);
  }
}
