namespace GqlPlus.Verifier.Ast;

internal sealed record class FieldAst(string Name)
  : AstNamedDirectives(Name), AstSelection
{
  protected override string Abbr => "F";

  internal string? Alias { get; init; }

  internal ArgumentAst? Argument { get; set; }

  internal ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  internal AstSelection[] Selections { get; set; } = Array.Empty<AstSelection>();

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && Alias.NullEqual(other.Alias)
    && Argument == other.Argument
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine((AstNamedDirectives)this, Alias, Argument, Modifiers, Selections);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Alias.Suffixed(":"))
      .Append(Argument?.ToString())
      .Append(string.Join("", Modifiers.Select(m => $"{m}")))
      .Concat(Selections.Bracket("{", "}", d => $"{d}"));
}
