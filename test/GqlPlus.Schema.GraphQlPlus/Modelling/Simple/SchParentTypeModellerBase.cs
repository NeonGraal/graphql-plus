namespace GqlPlus.Schema.Modelling;

internal abstract class SchParentTypeModellerBase<TAst, TAstItem, TSchItem, TSchAllItem>
  : ModellerBase<TAst, ISch_Type>
  where TAst : class, IAstSimple<TAstItem>
  where TAstItem : class, IAstError
  where TSchItem : class
  where TSchAllItem : class
{
  protected abstract Sch_TypeKind TypeKind { get; }
  protected abstract TSchItem MakeItem(TAstItem ast);
  protected abstract TSchAllItem MakeAllItem(string typeName, TAstItem ast);
  protected abstract ISch_Type WrapType(Sch_ParentType<Sch_TypeKind, TSchItem, TSchAllItem> parentType);

  protected override ISch_Type ToModel(TAst ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<TSchItem> items = [.. ast.Items.Select(MakeItem)];
    ICollection<TSchAllItem> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_ParentType<Sch_TypeKind, TSchItem, TSchAllItem> parentType = new() {
      As__ParentType = new Sch_ParentTypeObject<Sch_TypeKind, TSchItem, TSchAllItem>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        TypeKind,
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems),
    };

    return WrapType(parentType);
  }
}
