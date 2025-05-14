namespace GqlPlus.Modelling.Objects;

public class DualModellerTests
  : ModellerClassTestBase<IGqlpDualObject, TypeDualModel>
{
  public DualModellerTests()
  {
    IModeller<IGqlpDualAlternate, DualAlternateModel> objAlt = MFor<IGqlpDualAlternate, DualAlternateModel>();
    IModeller<IGqlpDualField, DualFieldModel> objField = MFor<IGqlpDualField, DualFieldModel>();
    IModeller<IGqlpDualBase, DualBaseModel> objBase = MFor<IGqlpDualBase, DualBaseModel>();

    Modeller = new DualModeller(objAlt, objField, objBase);
  }

  protected override IModeller<IGqlpDualObject, TypeDualModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeDualModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpDualObject ast = For<IGqlpDualObject>();
    ast.Name.Returns(name);
    ast.Description.Returns(content);
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
