namespace GqlPlus.Modelling.Objects;

public class InputArgModellerTests
  : ModellerClassTestBase<IGqlpObjArg, InputArgModel>
{
  public InputArgModellerTests()
  {
    IModeller<IGqlpObjArg, DualArgModel> dual = MFor<IGqlpObjArg, DualArgModel>();

    Modeller = new InputArgModeller(dual);
  }

  protected override IModeller<IGqlpObjArg, InputArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedInputArgModel(string input, string contents)
  {
    // Arrange
    IGqlpObjArg ast = A.Named<IGqlpObjArg>(input, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    InputArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(input),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
