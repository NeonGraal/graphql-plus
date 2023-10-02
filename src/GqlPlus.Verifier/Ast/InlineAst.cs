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

  public bool Equals(InlineAst? other)
    => other is not null
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections, Directives);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend("|")
      .Append(":" + OnType)
      .Concat(Directives.Select(d => $"{d}"))
      .Append("{")
      .Concat(Selections.Select(d => $"{d}"))
      .Append("}");
}
