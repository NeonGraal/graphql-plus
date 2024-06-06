﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class OutputFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpOutputBase Type
) : AstObjectField<IGqlpOutputBase>(At, Name, Description, Type)
  , IEquatable<OutputFieldAst>
  , IGqlpOutputField
{
  public InputParameterAst[] Parameters { get; set; } = [];

  internal override string Abbr => "OF";

  IEnumerable<IGqlpInputParameter> IGqlpOutputField.Parameters => Parameters;
  IGqlpOutputBase IGqlpObjectField<IGqlpOutputBase>.Type => Type;

  public OutputFieldAst(TokenAt at, string name, IGqlpOutputBase typeBase)
    : this(at, name, "", typeBase) { }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameters.SequenceEqual(other.Parameters);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameters.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameters.Bracket("(", ")"))
      .Concat(Type.GetFields().Prepend(string.IsNullOrWhiteSpace(Type.EnumMember) ? ":" : "="))
      .Concat(Modifiers.AsString());
}
