using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchUnionModeller
  : ModellerBase<IAstUnion, ISch_Type>
{
  protected override ISch_Type ToModel(IAstUnion ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_UnionRef> items = [.. ast.Items.Select(MakeItem)];
    ICollection<ISch_UnionMember> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_ParentType<Sch_TypeKind, ISch_UnionRef, ISch_UnionMember> unionType = new() {
      As__ParentType = new Sch_ParentTypeObject<Sch_TypeKind, ISch_UnionRef, ISch_UnionMember>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        Sch_TypeKind.Union,
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems),
    };

    return new Sch_Type {
      As_TypeKindUnion = unionType,
      As__Type = new Sch_TypeObject(),
    };
  }

  private static ISch_UnionRef MakeItem(IAstUnionMember ast)
  {
    Sch_UnionRef result = new();
    result.As__UnionRef = new Sch_UnionRefObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      Sch_SimpleKind.Union);
    return result;
  }

  private static Sch_UnionMember MakeAllItem(string unionName, IAstUnionMember ast)
  {
    Sch_UnionMember result = new();
    result.As__UnionMember = new Sch_UnionMemberObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      Sch_SimpleKind.Union,
      SchModellerHelpers.MakeName(unionName));
    return result;
  }
}
