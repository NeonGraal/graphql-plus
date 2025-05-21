namespace GqlPlus.Modelling.Objects;

public class OutputFieldModellerTests
  : ModellerClassTestBase<IGqlpOutputField, OutputFieldModel>
{
  private readonly IModeller<IGqlpOutputBase, OutputBaseModel> _objBase = MFor<IGqlpOutputBase, OutputBaseModel>();

  public OutputFieldModellerTests()
  {
    IModifierModeller modifier = For<IModifierModeller>();
    IModeller<IGqlpInputParam, InputParamModel> parameter = MFor<IGqlpInputParam, InputParamModel>();

    Modeller = new OutputFieldModeller(modifier, parameter, _objBase);
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
    _objBase.ToModel(type, TypeKinds).Returns(outputType);

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
