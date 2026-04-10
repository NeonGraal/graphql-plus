using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

internal class MergeSchemas(
  IMergerRepository mergers
) : GroupsMerger<IAstSchema>
{
  protected override string ItemGroupKey(IAstSchema item)
    => "Schema";

  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchema> group)
  {
    IGqlpSchemaCategory[] categories = Just<IGqlpSchemaCategory>(group);
    IGqlpSchemaDirective[] directives = Just<IGqlpSchemaDirective>(group);
    IGqlpSchemaOption[] options = Just<IGqlpSchemaOption>(group);
    IGqlpType[] astTypes = Just<IGqlpType>(group);

    IMessages categoriesCanMerge = categories.Length > 0 ? mergers.MergerFor<IGqlpSchemaCategory>().CanMerge(categories) : Messages.New;
    IMessages directivesCanMerge = directives.Length > 0 ? mergers.MergerFor<IGqlpSchemaDirective>().CanMerge(directives) : Messages.New;
    IMessages optionsCanMerge = options.Length > 0 ? mergers.MergerFor<IGqlpSchemaOption>().CanMerge(options) : Messages.New;
    IMessages astTypesCanMerge = astTypes.Length > 0 ? mergers.MergerFor<IGqlpType>().CanMerge(astTypes) : Messages.New;

    return categoriesCanMerge
      .Add(directivesCanMerge)
      .Add(optionsCanMerge)
      .Add(astTypesCanMerge);
  }

  private static TItem[] Just<TItem>(IEnumerable<IAstSchema> group)
    => [.. group.SelectMany(item => item.Declarations.OfType<TItem>())];

  protected override IAstSchema MergeGroup(IEnumerable<IAstSchema> group)
  {
    IGqlpSchemaCategory[] categories = Just<IGqlpSchemaCategory>(group);
    IGqlpSchemaDirective[] directives = Just<IGqlpSchemaDirective>(group);
    IGqlpSchemaOption[] options = Just<IGqlpSchemaOption>(group);
    IGqlpType[] astTypes = Just<IGqlpType>(group);

    IEnumerable<AstDeclaration> declarations = mergers.MergerFor<IGqlpSchemaCategory>()
      .Merge(categories).Cast<IAstDeclaration>()
      .Concat(mergers.MergerFor<IGqlpSchemaDirective>().Merge(directives))
      .Concat(mergers.MergerFor<IGqlpSchemaOption>().Merge(options))
      .Concat(mergers.MergerFor<IGqlpType>().Merge(astTypes))
      .Cast<AstDeclaration>();

    SchemaAst ast = (SchemaAst)group.First();

    return ast with { Declarations = [.. declarations] };
  }
}
