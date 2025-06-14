namespace GqlPlus.Modelling.Objects;

public class OutputFieldModellerTests
  : ModellerObjectBaseTestBase<IGqlpOutputField, OutputFieldModel, IGqlpOutputBase, OutputBaseModel>
{
  public OutputFieldModellerTests()
  {
    IModifierModeller modifier = A.Of<IModifierModeller>();
    IModeller<IGqlpInputParam, InputParamModel> parameter = MFor<IGqlpInputParam, InputParamModel>();

    Modeller = new OutputFieldModeller(modifier, parameter, ObjBase);
  }

  protected override IModeller<IGqlpOutputField, OutputFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedOutputFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IGqlpOutputField ast = A.OutputField(name, typeName, contents);

    OutputBaseModel outputType = new(typeName, "");
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
