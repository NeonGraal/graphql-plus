﻿namespace GqlPlus.Verifier.Ast;

internal sealed record class FieldAst(string Name)
  : AstNamedDirectives(Name), AstSelection
{
  public string? Alias { get; init; }
  public ArgumentAst? Argument { get; set; }
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  public AstSelection[] Selections { get; set; } = Array.Empty<AstSelection>();

  protected override string Abbr => "F";

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && Alias.NullEqual(other.Alias)
    && Argument == other.Argument
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Alias, Argument, Modifiers, Selections);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Alias.Suffixed(":"))
      .Append(Argument?.ToString())
      .Append(string.Join("", Modifiers.Select(m => $"{m}")))
      .Concat(Selections.Bracket("{", "}", d => $"{d}"));
}
