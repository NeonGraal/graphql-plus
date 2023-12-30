using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOptions(
  IMerge<ConstantAst> defaults
) : AliasedMerger<OptionDeclAst>
{
  protected override string ItemMatchKey(OptionDeclAst item)
    => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, OptionDeclAst> group)
    => base.CanMergeGroup(group)
      && group.ManyCanMerge(d => d.Settings.Select(s => s.Value), defaults);

  protected override OptionDeclAst MergeGroup(IEnumerable<OptionDeclAst> group)
    => base.MergeGroup(group) with {
      Settings = group
        .SelectMany(d => d.Settings)
        .GroupBy(s => s.Key, s => s.Value)
        .ToMap(c => c.Key, v => defaults.Merge(v).First()),
    };
}
