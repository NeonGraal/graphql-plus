using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputFieldAst(
  ITokenAt At,
  string Name,
  string Description,
  IGqlpObjBase Type
) : AstObjField(At, Name, Description, Type)
  , IGqlpOutputField
{
  public IGqlpInputParam? Parameter { get; set; }

  public OutputFieldAst(TokenAt at, string name, IGqlpObjBase type)
    : this(at, name, "", type) { }

  internal override string Abbr => "OF";

  public bool Equals(OutputFieldAst? other)
    => other is IGqlpOutputField field && Equals(field);
  public bool Equals(IGqlpOutputField? other)
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
