using GqlPlus;
using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class VariableAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IGqlpVariable
{
  public string? Type { get; set; }
  public IGqlpModifier[] Modifiers { get; set; } = [];
  public IGqlpConstant? DefaultValue { get; set; }

  internal override string Abbr => "v";

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  public bool Equals(VariableAst? other)
    => other is IGqlpVariable variable && Equals(variable);
  public bool Equals(IGqlpVariable other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && Modifiers.SequenceEqual(other.Modifiers)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Type.Prefixed(":"))
      .Concat(Modifiers.AsString())
      .Append(DefaultValue.Prefixed("="));
}
