namespace GqlPlus.Schema.Modelling;

internal sealed class SchSettingModeller
  : ModellerBase<IAstSchemaSetting, ISch_Setting>
{
  internal static IModeller<IAstSchemaSetting, ISch_Setting> Factory(ISchModellerRepository _)
    => new SchSettingModeller();
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
