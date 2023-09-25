namespace GqlPlus.Verifier;

internal class ModifierAst
{
  internal ModifierKind Kind { get; }
  internal string? Key { get; init; }
  internal bool? KeyOptional { get; init; }

  public ModifierAst(ModifierKind kind) => Kind = kind;
}
