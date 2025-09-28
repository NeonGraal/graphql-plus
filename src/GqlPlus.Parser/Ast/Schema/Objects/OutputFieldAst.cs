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
  public IGqlpInputParam[] Params { get; set; } = [];

  public OutputFieldAst(TokenAt at, string name, IGqlpObjBase type)
    : this(at, name, "", type) { }

  internal override string Abbr => "OF";

  IEnumerable<IGqlpInputParam> IGqlpOutputField.Params => Params;

  public bool Equals(OutputFieldAst? other)
    => other is IGqlpOutputField field && Equals(field);
  public bool Equals(IGqlpOutputField? other)
    => base.Equals(other)
    && Params.SequenceEqual(other!.Params)
    && EnumValue?.EnumLabel == other.EnumLabel;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Params.Length, EnumValue?.EnumLabel);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Params.Bracket("(", ")"))
      .Concat(TypeFields());
}
