namespace GqlPlus.Ast.Operation;

internal sealed record class InlineAst(
  ITokenAt At,
  string? OnType,
  params IAstSelection[] Selections
) : OpInlineAst(At, OnType)
  , IAstInline
{
  internal override string Abbr => "i";

  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(InlineAst? other)
    => other is IAstInline inline && Equals(inline);
  public bool Equals(IAstInline? other)
    => Equals(other as IAstOpInline)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Selections?.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Selections.Bracket("{", "}"));
}
