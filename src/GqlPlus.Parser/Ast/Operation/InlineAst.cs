namespace GqlPlus.Ast.Operation;

internal sealed record class InlineAst(
  ITokenAt At,
  params IAstSelection[] Selections
) : AstAbbreviated(At)
  , IAstInline
{
  public string? OnType { get; set; }

  public IAstDirective[] Directives { get; set; } = [];
  public IAstModifier[] Modifiers { get; set; } = [];

  internal override string Abbr => "i";

  IEnumerable<IAstDirective> IAstDirectives.Directives => Directives;
  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;
  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public bool Equals(InlineAst? other)
    => other is IAstInline inline && Equals(inline);
  public bool Equals(IAstInline? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives)
    && Modifiers.SequenceEqual(other.Modifiers)
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections?.Length, Directives.Length, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"))
      .Concat(Modifiers.AsString());
}
