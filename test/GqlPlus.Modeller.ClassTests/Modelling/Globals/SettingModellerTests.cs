namespace GqlPlus.Modelling.Globals;

public class SettingModellerTests
  : ModellerClassTestBase<IGqlpSchemaSetting, SettingModel>
{
  public SettingModellerTests()
  {
    IModeller<IGqlpConstant, ConstantModel> constant = MFor<IGqlpConstant, ConstantModel>();
    Modeller = new SettingModeller(constant);
  }

  protected override IModeller<IGqlpSchemaSetting, SettingModel> Modeller { get; }

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
    SettingModel result = Modeller.ToModel<SettingModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe("SettingName");
    result.Description.ShouldBe("Setting description");
  }
}
