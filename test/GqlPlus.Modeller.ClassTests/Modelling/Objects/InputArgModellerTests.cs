namespace GqlPlus.Modelling.Objects;

public class InputArgModellerTests
  : ModellerClassTestBase<IGqlpInputArg, InputArgModel>
{
  public InputArgModellerTests()
  {
    IModeller<IGqlpDualArg, DualArgModel> dual = MFor<IGqlpDualArg, DualArgModel>();

    Modeller = new InputArgModeller(dual);
  }

  protected override IModeller<IGqlpInputArg, InputArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedInputArgModel(string Input, string contents)
  {
    // Arrange
    IGqlpInputArg ast = For<IGqlpInputArg>();
    ast.Input.Returns(Input);
    ast.Description.Returns(contents);
    ast.IsTypeParam.Returns(true);

    // Act
    InputArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Input.ShouldBe(Input),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
