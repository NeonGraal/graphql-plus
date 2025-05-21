using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class FieldAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IGqlpField
{
  public string? FieldAlias { get; init; }
  public IGqlpArg? Arg { get; set; }
  public IGqlpModifier[] Modifiers { get; set; } = [];
  public IGqlpSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  IGqlpArg? IGqlpField.Arg => Arg;

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  IEnumerable<IGqlpSelection> IGqlpSelections.Selections => Selections;

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && FieldAlias.NullEqual(other.FieldAlias)
    && Arg.NullEqual(other.Arg)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), FieldAlias, Arg, Modifiers.Length, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, FieldAlias.Suffixed(":"), Identifier }
      .Concat(Arg.Bracket("(", ")"))
      .Append(string.Join("", Modifiers.AsString()))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
