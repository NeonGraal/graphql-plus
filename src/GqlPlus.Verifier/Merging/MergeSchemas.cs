using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeSchemas(
  IMerge<CategoryDeclAst> categoryMerger,
  IMerge<DirectiveDeclAst> directiveMerger,
  IMerge<AstType> astTypeMerger
) : GroupsMerger<SchemaAst>
{
  protected override string ItemGroupKey(SchemaAst item)
    => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, SchemaAst> group)
  {
    var categories = Just<CategoryDeclAst>(group);
    var directives = Just<DirectiveDeclAst>(group);
    var astTypes = Just<AstType>(group);

    var categoriesCanMerge = categories.Length == 0 || categoryMerger.CanMerge(categories);
    var directivesCanMerge = directives.Length == 0 || directiveMerger.CanMerge(directives);
    var astTypesCanMerge = astTypes.Length == 0 || astTypeMerger.CanMerge(astTypes);

    return categoriesCanMerge
     && directivesCanMerge
     && (astTypesCanMerge || true);
  }

  private static TItem[] Just<TItem>(IEnumerable<SchemaAst> group)
    => group.SelectMany(item => item.Declarations.OfType<TItem>()).ToArray();

  protected override SchemaAst MergeGroup(IEnumerable<SchemaAst> group)
  {
    var categories = Just<CategoryDeclAst>(group);
    var directives = Just<DirectiveDeclAst>(group);
    var astTypes = Just<AstType>(group);

    var declarations = categoryMerger.Merge(categories).Cast<AstDeclaration>()
      .Concat(directiveMerger.Merge(directives))
      .Concat(astTypeMerger.Merge(astTypes));

    return group.First() with { Declarations = [.. declarations] };
  }
}
