namespace GqlPlus.Modelling.Objects;

public class DualBaseModellerTests
  : ModellerClassTestBase<IGqlpDualBase, DualBaseModel>
{
  private readonly IModeller<IGqlpDualArg, DualArgModel> _objArg = MFor<IGqlpDualArg, DualArgModel>();

  public DualBaseModellerTests()
    => Modeller = new DualBaseModeller(_objArg);

  protected override IModeller<IGqlpDualBase, DualBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedDualBaseModel(string name, string contents)
  {
    // Arrange
    IGqlpDualBase ast = A.Named<IGqlpDualBase>(name, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    DualBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }

  [Theory, RepeatData]
  public void ToModel_WithArgs_ReturnsExpectedDualBaseModel(string name, string argName)
  {
    // Arrange
    IGqlpDualBase ast = A.Named<IGqlpDualBase>(name);
    IGqlpDualArg arg = A.Named<IGqlpDualArg>(argName);
    ast.Args.Returns([arg]);
    ast.BaseArgs.Returns([arg]);

    DualArgModel argModel = new(TypeKindModel.Dual, argName, "");
    ToModelReturns(_objArg, argModel);

    // Act
    DualBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Args.ShouldContain(argModel)
      );
  }
}
