using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging;

internal class MergeSchemas(
  IMerge<IGqlpSchemaCategory> categoryMerger,
  IMerge<IGqlpSchemaDirective> directiveMerger,
  IMerge<OptionDeclAst> optionMerger,
  IMerge<AstType> astTypeMerger
) : GroupsMerger<IGqlpSchema>
{
  protected override string ItemGroupKey(IGqlpSchema item)
    => "Schema";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpSchema> group)
  {
    IEnumerable<IGqlpSchemaCategory> categories = Just<IGqlpSchemaCategory>(group);
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

  private static IEnumerable<TItem> Just<TItem>(IEnumerable<IGqlpSchema> group)
    => group.SelectMany(item => item.Declarations.OfType<TItem>());

  protected override IGqlpSchema MergeGroup(IEnumerable<IGqlpSchema> group)
  {
    IEnumerable<IGqlpSchemaCategory> categories = Just<IGqlpSchemaCategory>(group);
    IEnumerable<IGqlpSchemaDirective> directives = Just<IGqlpSchemaDirective>(group);
    IEnumerable<OptionDeclAst> options = Just<OptionDeclAst>(group);
    IEnumerable<AstType> astTypes = Just<AstType>(group);

    IEnumerable<AstDeclaration> declarations = categoryMerger.Merge(categories).Cast<AstDeclaration>()
      .Concat(directiveMerger.Merge(directives).Cast<AstDeclaration>())
      .Concat(optionMerger.Merge(options))
      .Concat(astTypeMerger.Merge(astTypes));

    SchemaAst ast = (SchemaAst)group.First();

    return ast with { Declarations = [.. declarations] };
  }
}
