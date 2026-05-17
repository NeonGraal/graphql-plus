namespace GqlPlus.Schema.Modelling;

internal sealed class SchEnumModeller
  : SchParentTypeModellerBase<IAstEnum, IAstEnumLabel, ISch_Aliased, ISch_EnumLabel>
{
  protected override Sch_TypeKind TypeKind => Sch_TypeKind.Enum;

  protected override ISch_Type WrapType(Sch_ParentType<Sch_TypeKind, ISch_Aliased, ISch_EnumLabel> parentType)
    => new Sch_Type {
      As_TypeKindEnum = parentType,
      As__Type = new Sch_TypeObject(),
    };

  protected override ISch_Aliased MakeItem(IAstEnumLabel ast)
  {
    Sch_Aliased result = new();
    result.As__Aliased = new Sch_AliasedObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases));
    return result;
  }

  protected override ISch_EnumLabel MakeAllItem(string enumName, IAstEnumLabel ast)
  {
    Sch_EnumLabel result = new();
    result.As__EnumLabel = new Sch_EnumLabelObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases),
      SchModellerHelpers.MakeName(enumName));
    return result;
  }
}
