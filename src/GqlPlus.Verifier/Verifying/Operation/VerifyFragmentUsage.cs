using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyFragmentUsage(IVerifierRepository verifiers) : IdentifiedVerifier<IAstSpread, IAstFragment>(verifiers)
{
  public override string Label => "Spread";

  public override string UsageKey(IAstSpread item) => item.Identifier;

  protected override void VerifyDefinitions(Map<IAstFragment> defined, IMessages errors)
  {
    foreach (MapPair<IAstFragment> def in defined) {
      HashSet<string> visited = [];
      if (HasCycle(def.Value, defined, visited)) {
        errors.Add(def.Value.MakeError("Invalid Fragment definition. Fragment has cyclic dependency."));
      }
    }
  }

  private bool HasCycle(IAstFragment value, Map<IAstFragment> defined, HashSet<string> visited)
  {
    foreach (IAstSpread spread in value.Selections.OfType<IAstSpread>()) {
      if (visited.Contains(spread.Identifier)) {
        return true;
      }

      if (defined.TryGetValue(spread.Identifier, out IAstFragment? fragment)) {
        visited.Add(spread.Identifier);
        if (HasCycle(fragment, defined, visited)) {
          return true;
        }

        visited.Remove(spread.Identifier);
      }
    }

    return false;
  }

  internal static VerifyFragmentUsage Factory(IVerifierRepository v) => new(v);
}
