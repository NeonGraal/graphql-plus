using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpInputField>(At, Name, Description)
  , IGqlpInputObject
{
  public override TypeKind Kind => TypeKind.Input;

  public InputDeclAst(ITokenAt at, string name)
    : this(at, name, "")
  { }
}
