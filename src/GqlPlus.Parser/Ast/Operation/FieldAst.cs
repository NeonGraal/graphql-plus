using GqlPlus;

namespace GqlPlus.Ast.Operation;

internal sealed record class FieldAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IAstField
{
  public string? FieldAlias { get; init; }
  public IAstArg? Arg { get; set; }
  public IAstModifier[] Modifiers { get; set; } = [];
  public IAstSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  IAstArg? IAstField.Arg => Arg;

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && FieldAlias.NullEqual(other.FieldAlias)
    && Arg.NullEqual(other.Arg)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), FieldAlias, Arg.NullHashCode(), Modifiers.Length, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, FieldAlias.Suffixed(":"), Identifier }
      .Concat(Arg.Bracket("(", ")"))
      .Concat(Modifiers.AsString())
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
