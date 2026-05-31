namespace GqlPlus.Ast.Operation;

internal sealed record class FieldAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstField
{
  public string? FieldAlias { get; init; }
  public IAstArg? Arg { get; set; }
  public IAstSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  IAstArg? IAstField.Arg => Arg;

  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(FieldAst? other)
    => other is IAstField field && Equals(field);
  public bool Equals(IAstField? other)
    => base.Equals(other)
    && FieldAlias.NullEqual(other?.FieldAlias)
    && Arg.NullEqual(other?.Arg)
    && Selections.SequenceEqual(other?.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), FieldAlias, Arg.NullHashCode(), Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, FieldAlias.Suffixed(":"), Identifier }
      .Concat(Arg.Bracket("(", ")"))
      .Concat(Modifiers.AsString())
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
