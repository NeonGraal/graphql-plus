using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputParameterAst(
  TokenAt At,
  IGqlpInputBase Type
) : AstAbbreviated(At)
  , IEquatable<InputParameterAst>
  , IGqlpInputParameter
{
  public ModifierAst[] Modifiers { get; set; } = [];
  public ConstantAst? DefaultValue { get; set; }

  internal override string Abbr => "Pa";

  IGqlpInputBase IGqlpInputParameter.Type => Type;
  IGqlpConstant? IGqlpInputParameter.DefaultValue => DefaultValue;
  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  string IGqlpDescribed.Description => Type.Description;

  internal InputParameterAst(TokenAt at, string input, string description = "")
    : this(at, new InputBaseAst(at, input, description)) { }

  public bool Equals(InputParameterAst? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => new[] { "!" + Abbr }
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(DefaultValue.Prefixed("="));
}
