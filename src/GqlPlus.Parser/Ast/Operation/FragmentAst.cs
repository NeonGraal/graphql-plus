namespace GqlPlus.Ast.Operation;

internal sealed record class FragmentAst(
  ITokenAt At,
  string Identifier,
  string OnType,
  params IAstSelection[] Selections
) : AstDirectives(At, Identifier)
  , IAstFragment
  , IAstSelections
{
  internal override string Abbr => "t";

  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(FragmentAst? other)
    => other is IAstFragment fragment && Equals(fragment);
  public bool Equals(IAstFragment? other)
    => base.Equals(other)
    && OnType.NullEqual(other?.OnType);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), OnType);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"));
}
