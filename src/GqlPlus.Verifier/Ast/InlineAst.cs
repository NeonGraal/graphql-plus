namespace GqlPlus.Verifier.Ast;

internal sealed record class InlineAst(AstSelection[] Selections)
  : AstBase, AstDirectives, AstSelection, IEquatable<InlineAst>
{
  internal string? OnType { get; set; }

  DirectiveAst[] AstDirectives.Directives { get; set; } = Array.Empty<DirectiveAst>();
  internal DirectiveAst[] Directives
  {
    get => (this as AstDirectives).Directives;
    set => (this as AstDirectives).Directives = value;
  }
  protected override string Abbr => "I";

  public bool Equals(InlineAst? other)
    => other is not null
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections, Directives);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Directives.Select(d => $"{d}"))
      .Concat(Selections.Bracket("{", "}", d => $"{d}"));
}
