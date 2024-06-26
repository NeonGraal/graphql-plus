using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpDualBase BaseType
) : AstObjField<IGqlpDualBase>(At, Name, Description, BaseType)
  , IGqlpDualField
{
  public DualFieldAst(TokenAt at, string name, IGqlpDualBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "DF";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(BaseType.GetFields())
      .Concat(Modifiers.AsString());
}
