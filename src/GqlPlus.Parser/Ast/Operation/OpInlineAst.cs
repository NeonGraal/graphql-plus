namespace GqlPlus.Ast.Operation;

internal record class OpInlineAst(
  ITokenAt At,
  string? OnType
) : AstAbbreviated(At)
  , IAstOpInline
{
  public OpInlineAst(IAstOpInline inline)
    : this(inline.At, inline.OnType)
  {
    OpInlineAst mods = (OpInlineAst)inline;
    Modifiers = mods.Modifiers;
    Directives = mods.Directives;
  }

  public IAstDirective[] Directives { get; set; } = [];
  public IAstModifier[] Modifiers { get; set; } = [];

  internal override string Abbr => "oi";

  IEnumerable<IAstDirective> IAstDirectives.Directives => Directives;
  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  public virtual bool Equals(OpInlineAst? other)
    => other is IAstOpInline inline && Equals(inline);
  public bool Equals(IAstOpInline? other)
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
