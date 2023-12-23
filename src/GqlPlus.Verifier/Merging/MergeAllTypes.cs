using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllTypes(
  IMerge<EnumDeclAst> enums,
  IMerge<InputDeclAst> inputs,
  IMerge<OutputDeclAst> outputs,
  IMerge<ScalarDeclAst> scalars
) : NamedMerger<AstType>
{
  public override bool CanMerge(AstType[] items)
    => items.Select(i => i.GetType()).Distinct().Count() == 1;

  protected override string ItemMatchKey(AstType item)
    => item.GetType().Name;

  public override AstType[] Merge(AstType[] items)
  {
    if (items is null || items.Length < 2) {
      return items ?? [];
    }

    var enumTypes = items.OfType<EnumDeclAst>().ToArray();
    var inputTypes = items.OfType<InputDeclAst>().ToArray();
    var outputTypes = items.OfType<OutputDeclAst>().ToArray();
    var scalarTypes = items.OfType<ScalarDeclAst>().ToArray();

    var enumsMerged = enums.Merge(enumTypes);
    var inputsMerged = inputs.Merge(inputTypes);
    var outputsMerged = outputs.Merge(outputTypes);
    var scalarsMerged = scalars.Merge(scalarTypes);

    return [.. enumsMerged, .. inputsMerged, .. outputsMerged, .. scalarsMerged];
  }

  protected override AstType MergeGroup(AstType[] group) => throw new NotImplementedException();
}
