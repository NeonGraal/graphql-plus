namespace GqlPlus.Modelling.Objects;

public class DualArgModellerTests
  : ModellerClassTestBase<IGqlpDualArg, DualArgModel>
{
  protected override IModeller<IGqlpDualArg, DualArgModel> Modeller { get; }
    = new DualArgModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedDualArgModel(string dual, string contents)
  {
    // Arrange
    IGqlpDualArg ast = A.Descr<IGqlpDualArg>(contents);
    ast.Dual.Returns(dual);
    ast.IsTypeParam.Returns(true);

    // Act
    DualArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Dual.ShouldBe(dual),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
