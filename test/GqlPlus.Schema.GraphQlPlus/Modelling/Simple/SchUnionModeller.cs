namespace GqlPlus.Schema.Modelling;

internal sealed class SchUnionModeller
  : SchParentTypeModellerBase<IAstUnion, IAstUnionMember, ISch_UnionRef, ISch_UnionMember>
{
  internal static IModeller<IAstUnion, ISch_Type> Factory(ISchModellerRepository _)
    => new SchUnionModeller();
  protected override Sch_TypeKind TypeKind => Sch_TypeKind.Union;

  protected override ISch_Type WrapType(Sch_ParentType<Sch_TypeKind, ISch_UnionRef, ISch_UnionMember> parentType)
    => new Sch_Type {
      As_TypeKindUnion = parentType,
      As__Type = new Sch_TypeObject(),
    };

  protected override ISch_UnionRef MakeItem(IAstUnionMember ast)
  {
    Sch_UnionRef result = new();
    result.As__UnionRef = new Sch_UnionRefObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      Sch_SimpleKind.Union);
    return result;
  }

  protected override ISch_UnionMember MakeAllItem(string unionName, IAstUnionMember ast)
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
