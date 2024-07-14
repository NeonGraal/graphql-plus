using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpOutputBase BaseType
) : AstObjField<IGqlpOutputBase>(At, Name, Description, BaseType)
  , IEquatable<OutputFieldAst>
  , IGqlpOutputField
{
  public IGqlpInputParam[] Params { get; set; } = [];

  public OutputFieldAst(TokenAt at, string name, IGqlpOutputBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "OF";

  IEnumerable<IGqlpInputParam> IGqlpOutputField.Params => Params;

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Params.SequenceEqual(other.Params);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Params.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Params.Bracket("(", ")"))
      .Append(string.IsNullOrWhiteSpace(BaseType.EnumMember) ? ":" : "=")
      .Concat(BaseType.GetFields())
      .Concat(Modifiers.AsString());
}
