namespace GqlPlus.Modelling.Globals;

public class SettingModellerTests
  : ModellerClassTestBase
{
  private readonly SettingModeller _sut;

  public SettingModellerTests()
  {
    IModeller<IGqlpConstant, ConstantModel> constant = For<IModeller<IGqlpConstant, ConstantModel>>();
    _sut = new SettingModeller(constant);
  }

  [Theory, RepeatData]
  public void ToModel_WithValidSetting_ReturnsExpectedSettingModel(string value)
  {
    // Arrange
    IGqlpSchemaSetting ast = For<IGqlpSchemaSetting>();
    ast.Name.Returns("SettingName");
    IGqlpConstant constant = CFor(value);
    ast.Value.Returns(constant);
    ast.Description.Returns("Setting description");

    // Act
    SettingModel result = _sut.ToModel<SettingModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe("SettingName");
    result.Description.ShouldBe("Setting description");
  }
}
