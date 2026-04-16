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
    IAstSchemaCategory[] categories = Just<IAstSchemaCategory>(group);
    IAstSchemaDirective[] directives = Just<IAstSchemaDirective>(group);
    IAstSchemaOption[] options = Just<IAstSchemaOption>(group);
    IAstType[] astTypes = Just<IAstType>(group);

    IMessages categoriesCanMerge = categories.Length > 0 ? mergers.MergerFor<IAstSchemaCategory>().CanMerge(categories) : Messages.New;
    IMessages directivesCanMerge = directives.Length > 0 ? mergers.MergerFor<IAstSchemaDirective>().CanMerge(directives) : Messages.New;
    IMessages optionsCanMerge = options.Length > 0 ? mergers.MergerFor<IAstSchemaOption>().CanMerge(options) : Messages.New;
    IMessages astTypesCanMerge = astTypes.Length > 0 ? mergers.MergerFor<IAstType>().CanMerge(astTypes) : Messages.New;

    return categoriesCanMerge
      .Add(directivesCanMerge)
      .Add(optionsCanMerge)
      .Add(astTypesCanMerge);
  }

  private static TItem[] Just<TItem>(IEnumerable<IAstSchema> group)
    => [.. group.SelectMany(item => item.Declarations.OfType<TItem>())];

  protected override IAstSchema MergeGroup(IEnumerable<IAstSchema> group)
  {
    IAstSchemaCategory[] categories = Just<IAstSchemaCategory>(group);
    IAstSchemaDirective[] directives = Just<IAstSchemaDirective>(group);
    IAstSchemaOption[] options = Just<IAstSchemaOption>(group);
    IAstType[] astTypes = Just<IAstType>(group);

    IEnumerable<AstDeclaration> declarations = mergers.MergerFor<IAstSchemaCategory>()
      .Merge(categories).Cast<IAstDeclaration>()
      .Concat(mergers.MergerFor<IAstSchemaDirective>().Merge(directives))
      .Concat(mergers.MergerFor<IAstSchemaOption>().Merge(options))
      .Concat(mergers.MergerFor<IAstType>().Merge(astTypes))
      .Cast<AstDeclaration>();

    SchemaAst ast = (SchemaAst)group.First();

    return ast with { Declarations = [.. declarations] };
  }

  internal static MergeSchemas Factory(IMergerRepository m) => new(m);
}
