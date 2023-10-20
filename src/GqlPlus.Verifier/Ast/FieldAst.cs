namespace GqlPlus.Verifier.Ast;

internal sealed record class FieldAst(ParseAt At, string Name)
  : AstNamedDirectives(At, Name), AstSelection
{
  public string? Alias { get; init; }
  public ArgumentAst? Argument { get; set; }
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  public AstSelection[] Selections { get; set; } = Array.Empty<AstSelection>();

  internal override string Abbr => "F";

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
