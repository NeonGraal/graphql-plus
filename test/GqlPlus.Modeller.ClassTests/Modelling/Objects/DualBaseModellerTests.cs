namespace GqlPlus.Modelling.Objects;

public class DualBaseModellerTests
  : ModellerClassTestBase<IGqlpDualBase, DualBaseModel>
{
  public DualBaseModellerTests()
  {
    IModeller<IGqlpDualArg, DualArgModel> objArg = MFor<IGqlpDualArg, DualArgModel>();

    Modeller = new DualBaseModeller(objArg);
  }

  protected override IModeller<IGqlpDualBase, DualBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedDualBaseModel(string dual, string contents)
  {
    // Arrange
    IGqlpDualBase ast = A.Descr<IGqlpDualBase>(contents);
    ast.Dual.Returns(dual);
    ast.IsTypeParam.Returns(true);

    // Act
    DualBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Dual.ShouldBe(dual),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
