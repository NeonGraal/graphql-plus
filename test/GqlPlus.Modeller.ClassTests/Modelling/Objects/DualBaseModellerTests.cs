namespace GqlPlus.Modelling.Objects;

public class ObjBaseModellerTests
  : ModellerClassTestBase<IGqlpObjBase, ObjBaseModel>
{
  private readonly IModeller<IGqlpTypeArg, TypeArgModel> _objArg = MFor<IGqlpTypeArg, TypeArgModel>();

  public ObjBaseModellerTests()
    => Modeller = new ObjBaseModeller(_objArg);

  protected override IModeller<IGqlpObjBase, ObjBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedObjBaseModel(string name, string contents)
  {
    // Arrange
    IGqlpObjBase ast = A.Named<IGqlpObjBase>(name, contents);
    ast.IsTypeParam.Returns(true);

    // Act
    ObjBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }

  [Theory, RepeatData]
  public void ToModel_WithArgs_ReturnsExpectedObjBaseModel(string name, string argName)
  {
    // Arrange
    IGqlpObjBase ast = A.Named<IGqlpObjBase>(name);
    IGqlpTypeArg arg = A.Named<IGqlpTypeArg>(argName);
    ast.Args.Returns([arg]);

    TypeArgModel argModel = new(TypeKindModel.Dual, argName, "");
    ToModelReturns(_objArg, argModel);

    // Act
    ObjBaseModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Args.ShouldContain(argModel)
      );
  }
}
