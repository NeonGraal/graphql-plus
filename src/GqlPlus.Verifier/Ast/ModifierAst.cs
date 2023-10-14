namespace GqlPlus.Verifier.Ast;

internal record class ModifierAst(ParseAt At)
{
  internal static ModifierAst Optional(ParseAt at)
    => new(at, ModifierKind.Optional);
  internal static ModifierAst List(ParseAt at)
    => new(at, ModifierKind.List);

  private ModifierAst(ParseAt at, ModifierKind kind)
    : this(at)
    => Kind = kind;

  internal ModifierAst(ParseAt at, string key, bool optional)
    : this(at, ModifierKind.Dict)
    => (Key, KeyOptional) = (key, optional);

  internal ModifierKind Kind { get; }
  internal string? Key { get; init; }
  internal bool KeyOptional { get; init; }

  public override string ToString()
    => Kind switch {
      ModifierKind.Optional => "?",
      ModifierKind.List => "[]",
      ModifierKind.Dict => $"[{Key}" + (KeyOptional ? "?]" : "]"),
      _ => "!?!",
    };
}
