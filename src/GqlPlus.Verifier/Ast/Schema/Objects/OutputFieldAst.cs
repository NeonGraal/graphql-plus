﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public sealed record class OutputFieldAst(TokenAt At, string Name, string Description, OutputBaseAst Type)
  : AstObjectField<OutputBaseAst>(At, Name, Description, Type), IEquatable<OutputFieldAst>
{
  public ParameterAst[] Parameters { get; set; } = [];

  internal override string Abbr => "OF";

  public OutputFieldAst(TokenAt at, string name, OutputBaseAst typeBase)
    : this(at, name, "", typeBase) { }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameters.SequenceEqual(other.Parameters);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameters.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
        .Concat(Parameters.Bracket("(", ")"))
        .Concat(Type.GetFields().Prepend(string.IsNullOrWhiteSpace(Type.EnumValue) ? ":" : "="))
        .Concat(Modifiers.AsString());
}
