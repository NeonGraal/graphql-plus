using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputFieldAst(
  TokenAt At,
  string Name,
  string Description,
  InputBaseAst Type
) : AstObjectField<InputBaseAst>(At, Name, Description, Type)
  , IEquatable<InputFieldAst>
  , IGqlpInputField
{
  public ConstantAst? DefaultValue { get; set; }

  internal override string Abbr => "IF";

  IGqlpConstant? IGqlpInputField.DefaultValue => DefaultValue;
  IGqlpInputBase IGqlpObjectField<IGqlpInputBase>.Type => Type;

  public InputFieldAst(TokenAt at, string name, InputBaseAst typeBase)
    : this(at, name, "", typeBase) { }

  public bool Equals(InputFieldAst? other)
    => base.Equals(other)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(DefaultValue.Prefixed("="));
}
