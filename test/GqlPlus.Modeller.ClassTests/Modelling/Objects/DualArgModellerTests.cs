namespace GqlPlus.Modelling.Objects;

public class DualArgModellerTests
  : ModellerClassTestBase<IGqlpDualArg, DualArgModel>
{
  protected override IModeller<IGqlpDualArg, DualArgModel> Modeller { get; }
    = new DualArgModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedDualArgModel(string name, string contents)
  {
    // Arrange
    IGqlpDualArg ast = A.Descr<IGqlpDualArg>(contents);
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
