namespace GqlPlus.Ast.Operation;

internal sealed record class FieldAst(
  ITokenAt At,
  string Identifier
) : OpFieldAst(At, Identifier)
  , IAstField
{
  public IAstSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(FieldAst? other)
    => other is IAstField field && Equals(field);
  public bool Equals(IAstField? other)
    => base.Equals(other)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Selections.Bracket("{", "}"));
}
