namespace GqlPlus.Ast.Operation;

internal record class InlineAst(
  ITokenAt At,
  string? OnType
) : AstAbbreviated(At)
  , IAstInline
  , IAstSelections
{
  public InlineAst(IAstInline inline)
    : this(inline.At, inline.OnType)
  {
    InlineAst mods = (InlineAst)inline;
    Modifiers = mods.Modifiers;
    Directives = mods.Directives;
  }

  public IAstDirective[] Directives { get; set; } = [];
  public IAstModifier[] Modifiers { get; set; } = [];
  public IAstSelection[] Selections { get; set; } = [];

  internal override string Abbr => "i";

  IEnumerable<IAstDirective> IAstDirectives.Directives => Directives;
  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;
  IEnumerable<IAstSelection> IAstSelections.Selections => Selections;

  public virtual bool Equals(InlineAst? other)
    => other is IAstInline inline && Equals(inline);
  public bool Equals(IAstInline? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives)
    && Modifiers.SequenceEqual(other.Modifiers)
    && OnType.NullEqual(other.OnType);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Directives.Length, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Directives.AsString())
      .Concat(Modifiers.AsString());
}
