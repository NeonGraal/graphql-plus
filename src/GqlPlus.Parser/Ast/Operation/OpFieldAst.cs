namespace GqlPlus.Ast.Operation;

internal record class OpFieldAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstOpField
{
  public string? FieldAlias { get; init; }
  public IAstArg? Arg { get; set; }

  internal override string Abbr => "of";

  IAstArg? IAstOpField.Arg => Arg;


  public virtual bool Equals(OpFieldAst? other)
    => other is IAstOpField field && Equals(field);
  public bool Equals(IAstOpField? other)
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
