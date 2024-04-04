﻿using GqlPlus.Verifier.Ast.Schema;

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

  protected override bool CanMergeGroup(IGrouping<string, SchemaAst> group)
  {
    var categories = Just<CategoryDeclAst>(group);
    var directives = Just<DirectiveDeclAst>(group);
    var options = Just<OptionDeclAst>(group);
    var astTypes = Just<AstType>(group);

    var categoriesCanMerge = categories.Any() || categoryMerger.CanMerge(categories);
    var directivesCanMerge = directives.Any() || directiveMerger.CanMerge(directives);
    var optionsCanMerge = options.Any() || optionMerger.CanMerge(options);
    var astTypesCanMerge = astTypes.Any() || astTypeMerger.CanMerge(astTypes);

    return categoriesCanMerge
     && directivesCanMerge
     && optionsCanMerge
     && (astTypesCanMerge || true);
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
