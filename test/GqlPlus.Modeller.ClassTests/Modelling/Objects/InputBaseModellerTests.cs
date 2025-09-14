namespace GqlPlus.Modelling.Objects;

public class InputBaseModellerTests
  : ModellerClassTestBase<IGqlpInputBase, InputBaseModel>
{
  public InputBaseModellerTests()
  {
    IModeller<IGqlpObjArg, ObjTypeArgModel> objArg = MFor<IGqlpObjArg, ObjTypeArgModel>();

    Modeller = new InputBaseModeller(objArg);
  }

  protected override IModeller<IGqlpInputBase, InputBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedInputBaseModel(string input, string contents)
  {
    // Arrange
    IGqlpInputBase ast = A.Named<IGqlpInputBase>(input, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    InputBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(input),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
