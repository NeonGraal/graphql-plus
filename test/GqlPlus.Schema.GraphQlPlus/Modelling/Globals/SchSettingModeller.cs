namespace GqlPlus.Schema.Modelling;

internal sealed class SchSettingModeller
  : ModellerBase<IAstSchemaSetting, ISch_Setting>
{
  protected override ISch_Setting ToModel(IAstSchemaSetting ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_Setting result = new();
    result.As__Setting = new Sch_SettingObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      new GqlpValue());
    return result;
  }
}
