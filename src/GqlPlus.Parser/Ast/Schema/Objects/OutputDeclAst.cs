using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpOutputField>(At, Name, Description)
  , IGqlpOutputObject
{
  public override TypeKind Kind => TypeKind.Output;

  public OutputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
