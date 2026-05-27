namespace GqlPlus.Ast.Operation;

internal sealed record class VariableAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstVariable
{
  public string? Type { get; set; }
  public IAstConstant? DefaultValue { get; set; }

  internal override string Abbr => "v";

  public bool Equals(VariableAst? other)
    => other is IAstVariable variable && Equals(variable);
  public bool Equals(IAstVariable other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Type.Prefixed(":"))
      .Append(DefaultValue.Prefixed("="));
}
