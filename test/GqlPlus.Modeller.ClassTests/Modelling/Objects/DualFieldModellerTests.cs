namespace GqlPlus.Modelling.Objects;

public class DualFieldModellerTests
  : ModellerObjectBaseTestBase<IGqlpDualField, DualFieldModel, IGqlpDualBase, DualBaseModel>
{
  public DualFieldModellerTests()
  {
    IModifierModeller modifier = A.Of<IModifierModeller>();

    Modeller = new DualFieldModeller(modifier, ObjBase);
  }

  protected override IModeller<IGqlpDualField, DualFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedDualFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IGqlpDualField ast = A.DualField(name, typeName).SetDescr(contents);
    DualBaseModel dualType = new(typeName, "");
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
