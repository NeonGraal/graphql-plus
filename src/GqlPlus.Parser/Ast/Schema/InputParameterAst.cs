using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

public sealed record class InputParameterAst(
  TokenAt At,
  InputBaseAst Type
) : AstAlternate<InputBaseAst>(At, Type)
  , IEquatable<InputParameterAst>
  , IGqlpInputParameter
{
  public ConstantAst? DefaultValue { get; set; }

  internal override string Abbr => "Pa";

  IGqlpInputRef? IGqlpInputParameter.Type => default;
  IGqlpConstant? IGqlpInputParameter.DefaultValue => DefaultValue;

  internal InputParameterAst(TokenAt at, string input, string description = "")
    : this(at, new InputBaseAst(at, input, description)) { }

  public bool Equals(InputParameterAst? other)
    => base.Equals(other)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => new[] { "!" + Abbr }
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(DefaultValue.Prefixed("="));
}
