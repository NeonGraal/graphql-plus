namespace GqlPlus.Modelling.Objects;

public class ObjBaseModellerTests
  : ModellerClassTestBase<IAstObjBase, ObjBaseModel>
{
  private readonly IModeller<IAstTypeArg, TypeArgModel> _objArg = MFor<IAstTypeArg, TypeArgModel>();

  public ObjBaseModellerTests()
  {
    IModellerRepository modellers = A.Of<IModellerRepository>();
    ModellerForReturns(modellers, _objArg);
    Modeller = new ObjBaseModeller(modellers);
  }

  protected override IModeller<IAstObjBase, ObjBaseModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidBase_ReturnsExpectedObjBaseModel(string name, string contents)
  {
    // Arrange
    IAstObjBase ast = A.Named<IAstObjBase>(name, contents);
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
    IAstObjBase ast = A.Named<IAstObjBase>(name);
    IAstTypeArg arg = A.Named<IAstTypeArg>(argName);
    ast.Args.Returns([arg]);

    TypeArgModel argModel = new(TypeKindModel.Dual, argName, string.Empty);
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
