using GqlPlus.Token;

namespace GqlPlus.Ast;

public sealed record class ModifierAst(TokenAt At)
  : AstBase(At)
  , IEquatable<ModifierAst>
  , IGqlpModifier
{
  internal static ModifierAst Optional(TokenAt at)
    => new(at, ModifierKind.Optional, "?");
  internal static ModifierAst List(TokenAt at)
    => new(at, ModifierKind.List, "[]");

  internal static ModifierAst Dict(TokenAt at, string key, bool optional)
   => new(at, ModifierKind.Dict, "[" + key + (optional ? "?]" : "]")) {
     Key = key,
     IsOptional = optional
   };

  internal static ModifierAst Param(TokenAt at, string key, bool optional)
   => new(at, ModifierKind.Param, "[$" + key + (optional ? "?]" : "]")) {
     Key = key,
     IsOptional = optional
   };

  private ModifierAst(TokenAt at, ModifierKind kind, string toString)
    : this(at)
    => (Kind, _toString) = (kind, toString);

  public ModifierKind Kind { get; }
  public string? Key { get; init; }
  public bool IsOptional { get; init; }

  ModifierKind IGqlpModifier.ModifierKind => Kind;

  private readonly string _toString = "";

  public override string ToString()
    => _toString;

  // override object.Equals
  public bool Equals(ModifierAst? other)
    => other is not null
    && Kind == other.Kind
    && Key.NullEqual(other.Key)
    && IsOptional.NullEqual(other.IsOptional);

  // override object.GetHashCode
  public override int GetHashCode()
    => HashCode.Combine(Kind, Key, IsOptional);
}
