namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IAstSpread
{
  public IAstModifier[] Modifiers { get; set; } = [];

  internal override string Abbr => "s";

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  public bool Equals(SpreadAst? other)
    => base.Equals(other)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] { AbbrAt, Identifier }
      .Concat(Modifiers.AsString())
      .Concat(Directives.AsString());
}
