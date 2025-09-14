﻿namespace GqlPlus.Modelling.Objects;

public class OutputBaseModellerTests
  : ModellerClassTestBase<IGqlpOutputBase, OutputBaseModel>
{
  public OutputBaseModellerTests()
  {
    IModeller<IGqlpObjArg, ObjTypeArgModel> objArg = MFor<IGqlpObjArg, ObjTypeArgModel>();

    Modeller = new OutputBaseModeller(objArg);
  }

  protected override IModeller<IGqlpOutputBase, OutputBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedOutputBaseModel(string name, string contents)
  {
    // Arrange
    IGqlpOutputBase ast = A.Named<IGqlpOutputBase>(name, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    OutputBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
