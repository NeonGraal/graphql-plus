namespace GqlPlus.Ast.Operation;

internal record class FieldAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstField
  , IAstSelections
{
  public string? FieldAlias { get; init; }
  public IAstArg? Arg { get; set; }
  public IAstSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  IAstArg? IAstField.Arg => Arg;
  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public virtual bool Equals(FieldAst? other)
    => other is IAstField field && Equals(field);
  public bool Equals(IAstField? other)
    => base.Equals(other)
    && FieldAlias.NullEqual(other?.FieldAlias)
    && Arg.NullEqual(other?.Arg);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), FieldAlias, Arg.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, FieldAlias.Suffixed(":"), Identifier }
      .Concat(Arg.Bracket("(", ")"))
      .Concat(Modifiers.AsString())
      .Concat(Directives.AsString());
}
