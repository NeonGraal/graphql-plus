using GqlPlus.Building.Schema;

namespace GqlPlus.Modelling.Objects;

public class DualFieldModellerTests
  : ModellerObjectBaseTestBase<IAstDualField, DualFieldModel, ObjBaseModel>
{
  public DualFieldModellerTests()
  {
    IModifierModeller modifier = A.Of<IModifierModeller>();
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModifierModeller.Returns(modifier);
    ModellerForReturns(modellers, ObjBase);
    Modeller = new DualFieldModeller(modellers);
  }

  protected override IModeller<IAstDualField, DualFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedDualFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IAstDualField ast = A.DualField(name, typeName).WithDescr(contents).AsDualField;
    ObjBaseModel dualType = new(typeName, "");
    ToModelReturns(ObjBase, dualType);

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
