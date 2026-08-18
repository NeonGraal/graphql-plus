namespace GqlPlus.Ast.Operation;

internal sealed record class OperationBaseAst
  : IAstOperationBase
{
  public string Category { get; set; } = "query";
  public IAstVariable[] Variables { get; set; } = [];
  public IAstArg? Argument { get; set; }
  public IMap<IAstSelection[]> Selections { get; } = new Map<IAstSelection[]>();
  public IAstFragment[] Fragments { get; set; } = [];

  IEnumerable<IAstVariable> IAstOperationBase.Variables => Variables;
  IEnumerable<IAstFragment> IAstOperationBase.Fragments => Fragments;

  internal void SetSelections(IEnumerable<IAstSelection> selections, string prefix = "")
  {
    int i = 0;
    List<IAstSelection> list = [];
    foreach (IAstSelection selection in selections) {
      i++;
      if (selection is IAstSelections sub) {
        string key = $"{prefix}.{i}";
        SetSelections(sub.Selections, key);
      }

      list.Add(selection);
    }

    if (list.Count > 0) {
      Selections[prefix] = [.. list];
    }
  }

  internal void SetFragments(IEnumerable<IAstFragment> fragments)
  {
    Fragments = [.. fragments];
    foreach (IAstFragment fragment in Fragments) {
      if (fragment is IAstSelections selections) {
        SetSelections(selections.Selections, fragment.Identifier);
      }
    }
  }

  internal IEnumerable<string?> SelectionsFields()
    => Selections.Bracket("{", "}", p => p.Key + ": [ " + p.Value.Joined(v => $"{v}") + " ]");
}
