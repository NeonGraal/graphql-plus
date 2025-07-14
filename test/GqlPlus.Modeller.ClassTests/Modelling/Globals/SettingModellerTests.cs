namespace GqlPlus.Modelling.Globals;

public class SettingModellerTests
  : ModellerClassTestBase<IGqlpSchemaSetting, SettingModel>
{
  private readonly IModeller<IGqlpConstant, ConstantModel> _constant = MFor<IGqlpConstant, ConstantModel>();

  public SettingModellerTests()
    => Modeller = new SettingModeller(_constant);

  protected override IModeller<IGqlpSchemaSetting, SettingModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidSetting_ReturnsExpectedSettingModel(string name, string contents, string value)
  {
    // Arrange
    IGqlpConstant constant = A.Constant(value);
    IGqlpSchemaSetting ast = A.Named<IGqlpSchemaSetting>(name, contents);
    ast.Value.Returns(constant);

    ToModelReturns(_constant, constant, new ConstantModel(SimpleModel.Str(value)));

    // Act
    SettingModel result = Modeller.ToModel<SettingModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Value.ShouldNotBeNull()
          .Value.ShouldNotBeNull()
          .Text.ShouldBe(value)
      );
  }
}
