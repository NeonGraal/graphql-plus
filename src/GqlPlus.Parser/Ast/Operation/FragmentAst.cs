namespace GqlPlus.Ast.Operation;

internal sealed record class FragmentAst(
  ITokenAt At,
  string Identifier,
  string OnType,
  params IAstSelection[] Selections
) : AstDirectives(At, Identifier)
  , IAstFragment
{
  internal override string Abbr => "t";

  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(FragmentAst? other)
    => other is IAstFragment fragment && Equals(fragment);
  public bool Equals(IAstFragment? other)
    => base.Equals(other)
    && OnType.NullEqual(other?.OnType)
    && Selections.SequenceEqual(other?.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), OnType, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Selections.Bracket("{", "}"));
}
