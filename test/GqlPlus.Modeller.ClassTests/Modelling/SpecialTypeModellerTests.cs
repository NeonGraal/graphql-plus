﻿namespace GqlPlus.Modelling;

public class SpecialTypeModellerTests
  : ModellerClassTestBase<IGqlpTypeSpecial, SpecialTypeModel>
{
  protected override IModeller<IGqlpTypeSpecial, SpecialTypeModel> Modeller { get; }
    = new SpecialTypeModeller();

  [Fact]
  public void ToModel_WithValidSpecialType_ReturnsExpectedSpecialTypeModel()
  {
    // Arrange
    IGqlpTypeSpecial ast = For<IGqlpTypeSpecial>();
    ast.Name.Returns("SpecialType");
    ast.Description.Returns("A special type");
    ast.Aliases.Returns(["Alias1", "Alias2"]);

    // Act
    SpecialTypeModel result = Modeller.ToModel<SpecialTypeModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe("SpecialType");
    result.Description.ShouldBe("A special type");
    result.Aliases.ShouldContain("Alias1");
    result.Aliases.ShouldContain("Alias2");
  }
}
