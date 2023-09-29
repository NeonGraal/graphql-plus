namespace GqlPlus.Verifier.Ast;

internal record class ModifierAst(ModifierKind Kind)
{
  internal string? Key { get; init; }
  internal bool KeyOptional { get; init; }
}
