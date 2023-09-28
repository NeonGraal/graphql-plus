namespace GqlPlus.Verifier;

internal class ModifierAst : IEquatable<ModifierAst>
{
  internal ModifierKind Kind { get; }
  internal string? Key { get; init; }
  internal bool? KeyOptional { get; init; }

  public ModifierAst(ModifierKind kind) => Kind = kind;

  public bool Equals(ModifierAst? other) =>
    Kind switch {
      ModifierKind.Dict => CompareDict(other),
      _ => Kind == other?.Kind,
    };

  private bool CompareDict(ModifierAst? other)
  {
    if (other?.Kind == ModifierKind.Dict) {
      if ((Key ?? "") == (other.Key ?? "")) {
        return KeyOptional == other.KeyOptional;
      }
    }

    return false;
  }
}
