namespace GqlPlus.Verifier.Ast;

internal record class ModifierAst
{
  internal static readonly ModifierAst Optional = new(ModifierKind.Optional);
  internal static readonly ModifierAst List = new(ModifierKind.List);

  internal ModifierAst() => Kind = ModifierKind.Dict;
  private ModifierAst(ModifierKind kind) => Kind = kind;

  internal ModifierKind Kind { get; }
  internal string? Key { get; init; }
  internal bool KeyOptional { get; init; }
}
