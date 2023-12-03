namespace GqlPlus.Verifier.Ast;

public sealed record class ModifierAst(TokenAt At) : IEquatable<ModifierAst>
{
  internal static ModifierAst Optional(TokenAt at)
    => new(at, ModifierKind.Optional, "?");
  internal static ModifierAst List(TokenAt at)
    => new(at, ModifierKind.List, "[]");

  private ModifierAst(TokenAt at, ModifierKind kind, string toString)
    : this(at)
    => (Kind, _toString) = (kind, toString);

  internal ModifierAst(TokenAt at, string key, bool optional)
    : this(at, ModifierKind.Dict, "[" + key + (optional ? "?]" : "]"))
    => (Key, KeyOptional) = (key, optional);

  internal ModifierKind Kind { get; }
  internal string? Key { get; init; }
  internal bool KeyOptional { get; init; }

  private readonly string _toString = "";

  public override string ToString()
    => _toString;

  // override object.Equals
  public bool Equals(ModifierAst? other)
    => other is not null
    && Kind == other.Kind
    && Key.NullEqual(other.Key)
    && KeyOptional.NullEqual(other.KeyOptional);

  // override object.GetHashCode
  public override int GetHashCode()
    => HashCode.Combine(Kind, Key, KeyOptional);
}

internal enum ModifierKind
{
  Optional,
  List,
  Dict
}
