using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Operation;

public sealed record class FieldAst(TokenAt At, string Name)
  : AstDirectives(At, Name), IAstSelection, IAstModified
{
  public string? Alias { get; init; }
  public ArgumentAst? Argument { get; set; }
  public ModifierAst[] Modifiers { get; set; } = [];
  public IAstSelection[] Selections { get; set; } = [];

  internal override string Abbr => "f";

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && Alias.NullEqual(other.Alias)
    && Argument == other.Argument
    && Modifiers.SequenceEqual(other.Modifiers)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Alias, Argument, Modifiers.Length, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => //base.GetFields()
      new[] { AbbrAt, Alias.Suffixed(":"), Name }
      .Concat(Argument.Bracket("(", ")"))
      .Append(string.Join("", Modifiers.AsString()))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
