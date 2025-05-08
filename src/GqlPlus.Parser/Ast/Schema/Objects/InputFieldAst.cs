using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpInputBase BaseType
) : AstObjField<IGqlpInputBase>(At, Name, Description, BaseType)
  , IGqlpInputField
{
  public ConstantAst? DefaultValue { get; set; }

  public InputFieldAst(TokenAt at, string name, IGqlpInputBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "IF";

  IGqlpConstant? IGqlpInputField.DefaultValue => DefaultValue;

  public bool Equals(InputFieldAst? other)
    => other is IGqlpInputField field && Equals(field);
  public bool Equals(IGqlpInputField? other)
    => base.Equals(other)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(BaseType.GetFields())
      .Concat(Modifiers.AsString())
      .Append(DefaultValue.Prefixed("="));
}
