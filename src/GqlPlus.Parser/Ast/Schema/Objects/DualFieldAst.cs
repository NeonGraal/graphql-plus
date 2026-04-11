using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualFieldAst(
  ITokenAt At,
  string Name,
  string Description,
  IAstObjBase Type
) : AstObjField(At, Name, Description, Type)
  , IAstDualField
{
  public DualFieldAst(TokenAt at, string name, IAstObjBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "DF";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeFields());
}
