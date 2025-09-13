namespace GqlPlus.Modelling.Objects;

public class OutputArgModellerTests
  : ModellerClassTestBase<IGqlpObjArg, OutputArgModel>
{
  public OutputArgModellerTests()
  {
    IModeller<IGqlpObjArg, DualArgModel> dual = MFor<IGqlpObjArg, DualArgModel>();

    Modeller = new OutputArgModeller(dual);
  }

  protected override IModeller<IGqlpObjArg, OutputArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedOutputArgModel(string name, string contents)
  {
    // Arrange
    IGqlpObjArg ast = A.Named<IGqlpObjArg>(name, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    OutputArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
