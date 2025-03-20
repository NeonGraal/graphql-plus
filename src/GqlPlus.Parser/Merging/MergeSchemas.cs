using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Token;

namespace GqlPlus.Merging;

internal class MergeSchemas(
  IMerge<IGqlpSchemaCategory> categoryMerger,
  IMerge<IGqlpSchemaDirective> directiveMerger,
  IMerge<IGqlpSchemaOption> optionMerger,
  IMerge<IGqlpType> astTypeMerger
) : GroupsMerger<IGqlpSchema>
{
  protected override string ItemGroupKey(IGqlpSchema item)
    => "Schema";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpSchema> group)
  {
    IGqlpSchemaCategory[] categories = Just<IGqlpSchemaCategory>(group);
    IGqlpSchemaDirective[] directives = Just<IGqlpSchemaDirective>(group);
    IGqlpSchemaOption[] options = Just<IGqlpSchemaOption>(group);
    IGqlpType[] astTypes = Just<IGqlpType>(group);

    ITokenMessages categoriesCanMerge = categories.Length > 0 ? categoryMerger.CanMerge(categories) : TokenMessages.New;
    ITokenMessages directivesCanMerge = directives.Length > 0 ? directiveMerger.CanMerge(directives) : TokenMessages.New;
    ITokenMessages optionsCanMerge = options.Length > 0 ? optionMerger.CanMerge(options) : TokenMessages.New;
    ITokenMessages astTypesCanMerge = astTypes.Length > 0 ? astTypeMerger.CanMerge(astTypes) : TokenMessages.New;

    return categoriesCanMerge
      .Add(directivesCanMerge)
      .Add(optionsCanMerge)
      .Add(astTypesCanMerge);
  }

  private static TItem[] Just<TItem>(IEnumerable<IGqlpSchema> group)
    => [.. group.SelectMany(item => item.Declarations.OfType<TItem>())];

  protected override IGqlpSchema MergeGroup(IEnumerable<IGqlpSchema> group)
  {
    IGqlpSchemaCategory[] categories = Just<IGqlpSchemaCategory>(group);
    IGqlpSchemaDirective[] directives = Just<IGqlpSchemaDirective>(group);
    IGqlpSchemaOption[] options = Just<IGqlpSchemaOption>(group);
    IGqlpType[] astTypes = Just<IGqlpType>(group);

    IEnumerable<AstDeclaration> declarations = categoryMerger
      .Merge(categories).Cast<IGqlpDeclaration>()
      .Concat(directiveMerger.Merge(directives))
      .Concat(optionMerger.Merge(options))
      .Concat(astTypeMerger.Merge(astTypes))
      .Cast<AstDeclaration>();

    SchemaAst ast = (SchemaAst)group.First();

    return ast with { Declarations = [.. declarations] };
  }
}
