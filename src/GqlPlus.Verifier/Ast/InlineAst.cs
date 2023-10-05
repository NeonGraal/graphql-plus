namespace GqlPlus.Verifier.Ast;

internal sealed record class InlineAst(AstSelection[] Selections)
  : AstBase, AstDirectives, AstSelection, IEquatable<InlineAst>
{
  public string? OnType { get; set; }

  public DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();

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
