using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeSchemas(
  IMerge<CategoryDeclAst> categoryMerger,
  IMerge<DirectiveDeclAst> directiveMerger,
  IMerge<OptionDeclAst> optionMerger,
  IMerge<AstType> astTypeMerger
) : GroupsMerger<SchemaAst>
{
  protected override string ItemGroupKey(SchemaAst item)
    => "Schema";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, SchemaAst> group)
  {
    var categories = Just<CategoryDeclAst>(group);
    var directives = Just<DirectiveDeclAst>(group);
    var options = Just<OptionDeclAst>(group);
    var astTypes = Just<AstType>(group);

    var categoriesCanMerge = categories.Any() ? categoryMerger.CanMerge(categories) : new TokenMessages();
    var directivesCanMerge = directives.Any() ? directiveMerger.CanMerge(directives) : new TokenMessages();
    var optionsCanMerge = options.Any() ? optionMerger.CanMerge(options) : new TokenMessages();
    var astTypesCanMerge = astTypes.Any() ? astTypeMerger.CanMerge(astTypes) : new TokenMessages();

    return categoriesCanMerge
      .Add(directivesCanMerge)
      .Add(optionsCanMerge)
      .Add(astTypesCanMerge);
  }

  private static IEnumerable<TItem> Just<TItem>(IEnumerable<SchemaAst> group)
    => group.SelectMany(item => item.Declarations.OfType<TItem>());

  protected override SchemaAst MergeGroup(IEnumerable<SchemaAst> group)
  {
    var categories = Just<CategoryDeclAst>(group);
    var directives = Just<DirectiveDeclAst>(group);
    var options = Just<OptionDeclAst>(group);
    var astTypes = Just<AstType>(group);

    var declarations = categoryMerger.Merge(categories).Cast<AstDeclaration>()
      .Concat(directiveMerger.Merge(directives))
      .Concat(optionMerger.Merge(options))
      .Concat(astTypeMerger.Merge(astTypes));

    return group.First() with { Declarations = [.. declarations] };
  }
}
