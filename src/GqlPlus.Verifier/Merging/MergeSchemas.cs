using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Token;

namespace GqlPlus.Merging;

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
    IEnumerable<CategoryDeclAst> categories = Just<CategoryDeclAst>(group);
    IEnumerable<DirectiveDeclAst> directives = Just<DirectiveDeclAst>(group);
    IEnumerable<OptionDeclAst> options = Just<OptionDeclAst>(group);
    IEnumerable<AstType> astTypes = Just<AstType>(group);

    ITokenMessages categoriesCanMerge = categories.Any() ? categoryMerger.CanMerge(categories) : new TokenMessages();
    ITokenMessages directivesCanMerge = directives.Any() ? directiveMerger.CanMerge(directives) : new TokenMessages();
    ITokenMessages optionsCanMerge = options.Any() ? optionMerger.CanMerge(options) : new TokenMessages();
    ITokenMessages astTypesCanMerge = astTypes.Any() ? astTypeMerger.CanMerge(astTypes) : new TokenMessages();

    return categoriesCanMerge
      .Add(directivesCanMerge)
      .Add(optionsCanMerge)
      .Add(astTypesCanMerge);
  }

  private static IEnumerable<TItem> Just<TItem>(IEnumerable<SchemaAst> group)
    => group.SelectMany(item => item.Declarations.OfType<TItem>());

  protected override SchemaAst MergeGroup(IEnumerable<SchemaAst> group)
  {
    IEnumerable<CategoryDeclAst> categories = Just<CategoryDeclAst>(group);
    IEnumerable<DirectiveDeclAst> directives = Just<DirectiveDeclAst>(group);
    IEnumerable<OptionDeclAst> options = Just<OptionDeclAst>(group);
    IEnumerable<AstType> astTypes = Just<AstType>(group);

    IEnumerable<AstDeclaration> declarations = categoryMerger.Merge(categories).Cast<AstDeclaration>()
      .Concat(directiveMerger.Merge(directives))
      .Concat(optionMerger.Merge(options))
      .Concat(astTypeMerger.Merge(astTypes));

    return group.First() with { Declarations = [.. declarations] };
  }
}
