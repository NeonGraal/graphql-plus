using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Ast;

internal record class ModifierAst(ParseAt At) : IEquatable<ModifierAst>
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

  [ExcludeFromCodeCoverage]
  public override string ToString()
    => Kind switch {
      ModifierKind.Optional => "?",
      ModifierKind.List => "[]",
      ModifierKind.Dict => $"[{Key}" + (KeyOptional ? "?]" : "]"),
      _ => "!?!",
    };

  // override object.Equals
  public virtual bool Equals(ModifierAst? other)
    => other is not null
    && Kind == other.Kind
    && Key.NullEqual(other.Key)
    && KeyOptional.NullEqual(other.KeyOptional);

  // override object.GetHashCode
  public override int GetHashCode()
    => HashCode.Combine(Kind, Key, KeyOptional);
}
