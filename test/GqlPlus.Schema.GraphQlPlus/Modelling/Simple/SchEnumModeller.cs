using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchEnumModeller
  : ModellerBase<IAstEnum, ISch_Type>
{
  protected override ISch_Type ToModel(IAstEnum ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_Aliased> items = [.. ast.Items.Select(MakeItem)];
    ICollection<ISch_EnumLabel> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_ParentType<Sch_TypeKind, ISch_Aliased, ISch_EnumLabel> enumType = new() {
      As__ParentType = new Sch_ParentTypeObject<Sch_TypeKind, ISch_Aliased, ISch_EnumLabel>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        Sch_TypeKind.Enum,
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems),
    };

    return new Sch_Type {
      As_TypeKindEnum = enumType,
      As__Type = new Sch_TypeObject(),
    };
  }

  private static ISch_Aliased MakeItem(IAstEnumLabel ast)
  {
    Sch_Aliased result = new();
    result.As__Aliased = new Sch_AliasedObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases));
    return result;
  }

  private static Sch_EnumLabel MakeAllItem(string enumName, IAstEnumLabel ast)
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
