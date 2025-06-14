namespace GqlPlus.Modelling.Objects;

public class DualBaseModellerTests
  : ModellerClassTestBase<IGqlpDualBase, DualBaseModel>
{
  private readonly IModeller<IGqlpDualArg, DualArgModel> _objArg = MFor<IGqlpDualArg, DualArgModel>();

  public DualBaseModellerTests()
    => Modeller = new DualBaseModeller(_objArg);

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

  [Theory, RepeatData]
  public void ToModel_WithArgs_ReturnsExpectedDualBaseModel(string dual, string argName)
  {
    // Arrange
    IGqlpDualBase ast = A.Error<IGqlpDualBase>();
    ast.Dual.Returns(dual);
    IGqlpDualArg arg = A.Named<IGqlpDualArg>(argName);
    ast.Args.Returns([arg]);
    ast.BaseArgs.Returns([arg]);

    DualArgModel argModel = new(argName, "");
    ToModelReturns(_objArg, argModel);

    // Act
    DualBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Dual.ShouldBe(dual),
        r => r.Args.ShouldContain(argModel)
      );
  }
}
