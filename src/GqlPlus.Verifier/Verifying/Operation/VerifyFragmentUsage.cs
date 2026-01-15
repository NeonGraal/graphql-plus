using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyFragmentUsage(
    IVerify<IGqlpSpread> usage,
    IVerify<IGqlpFragment> definition
) : IdentifiedVerifier<IGqlpSpread, IGqlpFragment>(usage, definition)
{
  public override string Label => "Spread";

  public override string UsageKey(IGqlpSpread item) => item.Identifier;
  protected override void VerifyDefinitions(Dictionary<string, IGqlpFragment> defined, IMessages errors)
  {
    foreach (MapPair<IGqlpFragment> def in defined) {
      HashSet<string> visited = [];
      if (HasCycle(def.Value, defined, visited)) {
        errors.Add(def.Value.MakeError("Invalid Fragment definition. Fragment has cyclic dependency."));
      }
    }
  }

  private bool HasCycle(IGqlpFragment value, Dictionary<string, IGqlpFragment> defined, HashSet<string> visited)
  {
    foreach (IGqlpSpread spread in value.Selections.OfType<IGqlpSpread>()) {
      if (visited.Contains(spread.Identifier)) {
        return true;
      }

      if (defined.TryGetValue(spread.Identifier, out IGqlpFragment? fragment)) {
        visited.Add(spread.Identifier);
        if (HasCycle(fragment, defined, visited)) {
          return true;
        }

        visited.Remove(spread.Identifier);
      }
    }

    return false;
  }
}
