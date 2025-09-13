namespace GqlPlus.Modelling.Objects;

public class DualArgModellerTests
  : ModellerClassTestBase<IGqlpObjArg, DualArgModel>
{
  protected override IModeller<IGqlpObjArg, DualArgModel> Modeller { get; }
    = new DualArgModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedDualArgModel(string name, string contents)
  {
    // Arrange
    IGqlpObjArg ast = A.Descr<IGqlpObjArg>(contents);
    ast.Name.Returns(name);
    ast.IsTypeParam.Returns(true);

    // Act
    DualArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
