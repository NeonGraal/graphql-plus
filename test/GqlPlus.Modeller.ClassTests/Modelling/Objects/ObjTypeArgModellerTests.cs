namespace GqlPlus.Modelling.Objects;

public class ObjTypeArgModellerTests
  : ModellerClassTestBase<IGqlpObjTypeArg, ObjTypeArgModel>
{
  public ObjTypeArgModellerTests() => Modeller = new ObjTypeArgModeller();

  protected override IModeller<IGqlpObjTypeArg, ObjTypeArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedOutputArgModel(string name, string contents)
  {
    // Arrange
    IGqlpObjTypeArg ast = A.Named<IGqlpObjTypeArg>(name, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    ObjTypeArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
