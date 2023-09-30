namespace GqlPlus.Verifier.Ast;

internal sealed record class InlineAst(SelectionAst[] Selections)
  : DirectivesAst, SelectionAst, IEquatable<InlineAst>
{
  internal string? OnType { get; set; }

  DirectiveAst[] DirectivesAst.Directives { get; set; } = Array.Empty<DirectiveAst>();
  internal DirectiveAst[] Directives
  {
    get => (this as DirectivesAst).Directives;
    set => (this as DirectivesAst).Directives = value;
  }

  public bool Equals(InlineAst? other)
    => other is not null
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections)
    && Directives.SequenceEqual(other.Directives);

  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections, Directives);
}
