namespace GqlPlus.Verifier.Ast;

internal sealed record class InlineAst(ParseAt At, params AstSelection[] Selections)
  : AstBase(At), AstDirectives, AstSelection, IEquatable<InlineAst>
{
  public string? OnType { get; set; }

  public DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();

  internal override string Abbr => "I";

  public bool Equals(InlineAst? other)
    => base.Equals(other)
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections.Length, Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
