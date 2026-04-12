namespace GqlPlus.Modelling.Globals;

public class SettingModellerTests
  : ModellerClassTestBase<IAstSchemaSetting, SettingModel>
{
  private readonly IModeller<IAstConstant, ConstantModel> _constant = MFor<IAstConstant, ConstantModel>();

  public SettingModellerTests()
  {
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstConstant, ConstantModel>().Returns(_constant);
    Modeller = new SettingModeller(modellers);
  }

  protected override IModeller<IAstSchemaSetting, SettingModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidSetting_ReturnsExpectedSettingModel(string name, string contents, string value)
  {
    // Arrange
    IAstConstant constant = A.Constant(value);
    IAstSchemaSetting ast = A.Named<IAstSchemaSetting>(name, contents);
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
