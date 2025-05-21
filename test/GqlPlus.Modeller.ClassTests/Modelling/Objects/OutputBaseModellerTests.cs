namespace GqlPlus.Modelling.Objects;

public class OutputBaseModellerTests
  : ModellerClassTestBase<IGqlpOutputBase, OutputBaseModel>
{
  public OutputBaseModellerTests()
  {
    IModeller<IGqlpOutputArg, OutputArgModel> objArg = MFor<IGqlpOutputArg, OutputArgModel>();
    IModeller<IGqlpDualBase, DualBaseModel> dual = MFor<IGqlpDualBase, DualBaseModel>();

    Modeller = new OutputBaseModeller(objArg, dual);
  }

  protected override IModeller<IGqlpOutputBase, OutputBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedOutputBaseModel(string Output, string contents)
  {
    // Arrange
    IGqlpOutputBase ast = For<IGqlpOutputBase>();
    ast.Output.Returns(Output);
    ast.Description.Returns(contents);
    ast.IsTypeParam.Returns(true);

    // Act
    OutputBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Output.ShouldBe(Output),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }
}
