using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

internal class MergeSchemas(
  IMergerRepository mergers
) : GroupsMerger<IAstSchema>
{
  private readonly Defer<IMerge<IAstSchemaCategory>>.L _categories = mergers.MergerFor<IAstSchemaCategory>();
  private readonly Defer<IMerge<IAstSchemaDirective>>.L _directives = mergers.MergerFor<IAstSchemaDirective>();
  private readonly Defer<IMerge<IAstSchemaOption>>.L _options = mergers.MergerFor<IAstSchemaOption>();
  private readonly Defer<IMerge<IAstType>>.L _astTypes = mergers.MergerFor<IAstType>();

  protected override string ItemGroupKey(IAstSchema item)
    => "Schema";

  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchema> group)
  {
    IAstSchemaCategory[] categories = Just<IAstSchemaCategory>(group);
    IAstSchemaDirective[] directives = Just<IAstSchemaDirective>(group);
    IAstSchemaOption[] options = Just<IAstSchemaOption>(group);
    IAstType[] astTypes = Just<IAstType>(group);

    IMessages categoriesCanMerge = categories.Length > 0 ? _categories.I.CanMerge(categories) : Messages.New;
    IMessages directivesCanMerge = directives.Length > 0 ? _directives.I.CanMerge(directives) : Messages.New;
    IMessages optionsCanMerge = options.Length > 0 ? _options.I.CanMerge(options) : Messages.New;
    IMessages astTypesCanMerge = astTypes.Length > 0 ? _astTypes.I.CanMerge(astTypes) : Messages.New;

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

    IEnumerable<AstDeclaration> declarations = _categories.I
      .Merge(categories).Cast<IAstDeclaration>()
      .Concat(_directives.I.Merge(directives))
      .Concat(_options.I.Merge(options))
      .Concat(_astTypes.I.Merge(astTypes))
      .Cast<AstDeclaration>();

    SchemaAst ast = (SchemaAst)group.First();

    return ast with { Declarations = [.. declarations] };
  }

  internal static MergeSchemas Factory(IMergerRepository m) => new(m);
}
