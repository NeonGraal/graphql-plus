using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputFieldAst(
  ITokenAt At,
  string Name,
  string Description,
  IAstObjBase Type
) : AstObjField(At, Name, Description, Type)
  , IAstOutputField
{
  public IAstInputParam? Parameter { get; set; }

  public OutputFieldAst(TokenAt at, string name, IAstObjBase type)
    : this(at, name, "", type) { }

  internal override string Abbr => "OF";

  public bool Equals(OutputFieldAst? other)
    => other is IAstOutputField field && Equals(field);
  public bool Equals(IAstOutputField? other)
    => base.Equals(other)
    && Parameter.NullEqual(other?.Parameter)
    && EnumValue.NullEqual(other?.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameter, EnumValue.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Parameter.Bracket("(", ")"))
      .Concat(TypeFields());
}
