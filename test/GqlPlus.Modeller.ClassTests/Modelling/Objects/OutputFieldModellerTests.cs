using GqlPlus.Building.Schema;

namespace GqlPlus.Modelling.Objects;

public class OutputFieldModellerTests
  : ModellerObjectBaseTestBase<IAstOutputField, OutputFieldModel, ObjBaseModel>
{
  public OutputFieldModellerTests()
  {
    IModifierModeller modifier = A.Of<IModifierModeller>();
    IModeller<IAstInputParam, InputParamModel> parameter = MFor<IAstInputParam, InputParamModel>();

    Modeller = new OutputFieldModeller(modifier, parameter, ObjBase);
  }

  protected override IModeller<IAstOutputField, OutputFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedOutputFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IAstOutputField ast = A.OutputField(name, typeName).WithDescr(contents).AsOutputField;

    ObjBaseModel outputType = new(typeName, "");
    ToModelReturns(ObjBase, outputType);

    // Act
    OutputFieldModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Type.ShouldBe(outputType)
      );
  }
}
