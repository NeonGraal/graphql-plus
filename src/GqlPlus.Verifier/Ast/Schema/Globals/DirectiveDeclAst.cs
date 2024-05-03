﻿using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

public sealed record class DirectiveDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description), IEquatable<DirectiveDeclAst>
{
  public DirectiveOption Option { get; set; } = DirectiveOption.Unique;
  public ParameterAst[] Parameters { get; set; } = [];
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override string Abbr => "Di";

  public DirectiveDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(DirectiveDeclAst? other)
    => base.Equals(other)
    && Option == other.Option
    && Parameters.SequenceEqual(other.Parameters)
    && Locations == other.Locations;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameters.Bracket("(", ")"))
      .Append($"({Option})")
      .Append(Locations.ToString());
}

public enum DirectiveOption
{
  Unique,
  Repeatable,
}

[Flags]
public enum DirectiveLocation
{
  None = 0,
  All = 63,

  Operation = 1,
  Variable = 2,
  Field = 4,
  Inline = 8,
  Spread = 16,
  Fragment = 32,
}
