namespace GqlPlus.Modelling.Objects;

public class OutputFieldModellerTests
  : ModellerObjectBaseTestBase<IGqlpOutputField, OutputFieldModel, IGqlpOutputBase, OutputBaseModel>
{
  public OutputFieldModellerTests()
  {
    IModifierModeller modifier = For<IModifierModeller>();
    IModeller<IGqlpInputParam, InputParamModel> parameter = MFor<IGqlpInputParam, InputParamModel>();

    Modeller = new OutputFieldModeller(modifier, parameter, ObjBase);
  }

  protected override IModeller<IGqlpOutputField, OutputFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedOutputFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IGqlpOutputField ast = NFor<IGqlpOutputField>(name);
    ast.Description.Returns(contents);
    IGqlpOutputBase type = For<IGqlpOutputBase>();
    type.Output.Returns(typeName);
    ast.BaseType.Returns(type);
    OutputBaseModel outputType = new(typeName, "");
    ObjBase.ToModel(type, TypeKinds).Returns(outputType);

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
