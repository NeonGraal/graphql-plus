﻿namespace GqlPlus.Verifier.Ast.Operation;

internal sealed record class FieldAst(ParseAt At, string Name)
  : AstDirectives(At, Name), IAstSelection
{
  public string? Alias { get; init; }
  public ArgumentAst? Argument { get; set; }
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  public IAstSelection[] Selections { get; set; } = Array.Empty<IAstSelection>();

  internal override string Abbr => "f";

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && Alias.NullEqual(other.Alias)
    && Argument == other.Argument
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Alias, Argument, Modifiers.Length, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, Alias.Suffixed(":"), Name }
      .Concat(AstExtensions.Bracket("(", ")", new[] { Argument }))
      .Append(string.Join("", Modifiers.AsString()))
      .Concat(Directives.AsString())
      .Concat(AstExtensions.Bracket("{", "}", Selections));
}
