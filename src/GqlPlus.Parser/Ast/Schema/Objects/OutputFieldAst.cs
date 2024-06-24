﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class OutputFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpOutputBase BaseType
) : AstObjField<IGqlpOutputBase>(At, Name, Description, BaseType)
  , IEquatable<OutputFieldAst>
  , IGqlpOutputField
{
  public IGqlpInputParameter[] Parameters { get; set; } = [];

  public OutputFieldAst(TokenAt at, string name, IGqlpOutputBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "OF";

  IEnumerable<IGqlpInputParameter> IGqlpOutputField.Parameters => Parameters;

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameters.SequenceEqual(other.Parameters);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameters.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameters.Bracket("(", ")"))
      .Concat(BaseType.GetFields().Prepend(string.IsNullOrWhiteSpace(BaseType.EnumMember) ? ":" : "="))
      .Concat(Modifiers.AsString());
}
