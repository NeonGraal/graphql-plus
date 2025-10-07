using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualFieldAst(
  ITokenAt At,
  string Name,
  string Description,
  IGqlpObjBase Type
) : AstObjField(At, Name, Description, Type)
  , IGqlpDualField
{
  public DualFieldAst(TokenAt at, string name, IGqlpObjBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "DF";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeFields());
}
