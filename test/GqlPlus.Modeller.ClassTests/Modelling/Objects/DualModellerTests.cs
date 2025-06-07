namespace GqlPlus.Modelling.Objects;

public class DualModellerTests
  : ModellerObjectBaseTestBase<IGqlpDualObject, TypeDualModel, IGqlpDualBase, DualBaseModel>
{
  public DualModellerTests()
  {
    IModeller<IGqlpTypeParam, TypeParamModel> typeParam = MFor<IGqlpTypeParam, TypeParamModel>();
    IModeller<IGqlpDualAlternate, DualAlternateModel> objAlt = MFor<IGqlpDualAlternate, DualAlternateModel>();
    IModeller<IGqlpDualField, DualFieldModel> objField = MFor<IGqlpDualField, DualFieldModel>();

    Modeller = new DualModeller(new(typeParam, objAlt, objField, ObjBase));
  }

  protected override IModeller<IGqlpDualObject, TypeDualModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeDualModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpDualObject ast = A.Named<IGqlpDualObject>(name, content);
    ast.Aliases.Returns(aliases);

    // Act
    TypeDualModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(content),
        r => r.Aliases.ShouldBe(aliases));
  }
}
