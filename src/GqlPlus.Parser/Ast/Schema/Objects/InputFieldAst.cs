using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputFieldAst(
  ITokenAt At,
  string Name,
  string Description,
  IGqlpObjBase Type
) : AstObjField(At, Name, Description, Type)
  , IGqlpInputField
{
  public IGqlpConstant? DefaultValue { get; set; }

  public InputFieldAst(TokenAt at, string name, IGqlpObjBase type)
    : this(at, name, "", type) { }

  internal override string Abbr => "IF";

  public bool Equals(InputFieldAst? other)
    => other is IGqlpInputField field && Equals(field);
  public bool Equals(IGqlpInputField? other)
    => base.Equals(other)
    && DefaultValue.NullEqual(other!.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeFields(DefaultValue.Prefixed("=")));
}
