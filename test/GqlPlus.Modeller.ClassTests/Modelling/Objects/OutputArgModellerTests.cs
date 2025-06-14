namespace GqlPlus.Modelling.Objects;

public class OutputArgModellerTests
  : ModellerClassTestBase<IGqlpOutputArg, OutputArgModel>
{
  public OutputArgModellerTests()
  {
    IModeller<IGqlpDualArg, DualArgModel> dual = MFor<IGqlpDualArg, DualArgModel>();

    Modeller = new OutputArgModeller(dual);
  }

  protected override IModeller<IGqlpOutputArg, OutputArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedOutputArgModel(string output, string contents)
  {
    // Arrange
    IGqlpOutputArg ast = A.Descr<IGqlpOutputArg>(contents);
    ast.Output.Returns(output);
    ast.IsTypeParam.Returns(true);

    // Act
    OutputArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Output.ShouldBe(output),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
