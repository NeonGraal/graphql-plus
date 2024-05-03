﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public sealed record class OutputBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjectBase<OutputBaseAst>(At, Name, Description)
  , IEquatable<OutputBaseAst>
{
  public OutputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumValue { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  public override bool Equals(OutputBaseAst? other)
    => base.Equals(other)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumValue);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      string.IsNullOrWhiteSpace(EnumValue)
        ? IsTypeParameter ? Name.Prefixed("$") : Name
        : $"{Name}.{EnumValue}"
    }.Concat(Arguments.Bracket("<", ">"));

  internal DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      Arguments = [.. Arguments.Select(a => a.ToDual())],
    };
}
