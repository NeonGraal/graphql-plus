using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class FieldAst(
  TokenAt At,
  string Name
) : AstDirectives(At, Name)
  , IGqlpField
{
  public string? FieldAlias { get; init; }
  public ArgumentAst? Argument { get; set; }
  public IGqlpModifier[] Modifiers { get; set; } = [];
  public IGqlpSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  IGqlpArgument? IGqlpField.Argument => Argument;

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  IEnumerable<IGqlpSelection> IGqlpField.Selections => Selections;

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && FieldAlias.NullEqual(other.FieldAlias)
    && Argument == other.Argument
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), FieldAlias, Argument, Modifiers.Length, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, FieldAlias.Suffixed(":"), Name }
      .Concat(Argument.Bracket("(", ")"))
      .Append(string.Join("", Modifiers.AsString()))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
