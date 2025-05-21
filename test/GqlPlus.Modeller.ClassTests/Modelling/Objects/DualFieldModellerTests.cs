namespace GqlPlus.Modelling.Objects;

public class DualFieldModellerTests
  : ModellerClassTestBase<IGqlpDualField, DualFieldModel>
{
  private readonly IModeller<IGqlpDualBase, DualBaseModel> _objBase = MFor<IGqlpDualBase, DualBaseModel>();

  public DualFieldModellerTests()
  {
    IModifierModeller modifier = For<IModifierModeller>();

    Modeller = new DualFieldModeller(modifier, _objBase);
  }

  protected override IModeller<IGqlpDualField, DualFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedDualFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IGqlpDualField ast = NFor<IGqlpDualField>(name);
    ast.Description.Returns(contents);
    IGqlpDualBase type = For<IGqlpDualBase>();
    type.Dual.Returns(typeName);
    ast.BaseType.Returns(type);
    DualBaseModel dualType = new(typeName, "");
    _objBase.ToModel(type, TypeKinds).Returns(dualType);

    // Act
    DualFieldModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Type.ShouldBe(dualType)
      );
  }
}
