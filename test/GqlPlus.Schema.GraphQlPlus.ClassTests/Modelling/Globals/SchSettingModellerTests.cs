namespace GqlPlus.Schema.Modelling.Globals;

public class SchSettingModellerTests
  : SchModellerClassTestBase<IAstSchemaSetting, ISch_Setting>
{
  protected override IModeller<IAstSchemaSetting, ISch_Setting> Modeller { get; } = new SchSettingModeller();

  [Fact]
  public void ToModel_ValidSetting_ReturnsSettingDiscriminator()
  {
    IAstSchemaSetting ast = A.Named<IAstSchemaSetting>("setting", "contents");
    IAstConstant value = A.Constant("value");
    ast.Value.Returns(value);

    ISch_Setting result = Modeller.ToModel(ast, TypeKinds);

    result.As__Setting.ShouldNotBeNull();
  }
}
