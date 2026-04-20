using GqlPlus;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputFieldAst(
  ITokenAt At,
  string Name,
  string Description,
  IAstObjBase Type
) : AstObjField(At, Name, Description, Type)
  , IAstInputField
{
  public IAstConstant? DefaultValue { get; set; }

  public InputFieldAst(TokenAt at, string name, IAstObjBase type)
    : this(at, name, "", type) { }

  internal override string Abbr => "IF";

  public bool Equals(InputFieldAst? other)
    => other is IAstInputField field && Equals(field);
  public bool Equals(IAstInputField? other)
    => base.Equals(other)
    && DefaultValue.NullEqual(other!.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DefaultValue.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeFields(DefaultValue.Prefixed("=")));
}
