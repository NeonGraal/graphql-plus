namespace GqlPlus.Modelling.Objects;

public class InputBaseModellerTests
  : ModellerClassTestBase<IGqlpInputBase, InputBaseModel>
{
  public InputBaseModellerTests()
  {
    IModeller<IGqlpInputArg, InputArgModel> objArg = MFor<IGqlpInputArg, InputArgModel>();
    IModeller<IGqlpDualBase, DualBaseModel> dual = MFor<IGqlpDualBase, DualBaseModel>();

    Modeller = new InputBaseModeller(objArg, dual);
  }

  protected override IModeller<IGqlpInputBase, InputBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedInputBaseModel(string input, string contents)
  {
    // Arrange
    IGqlpInputBase ast = A.Descr<IGqlpInputBase>(contents);
    ast.Input.Returns(input);
    ast.IsTypeParam.Returns(true);

    // Act
    InputBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Input.ShouldBe(input),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
