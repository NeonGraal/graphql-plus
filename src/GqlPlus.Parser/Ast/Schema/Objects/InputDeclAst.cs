using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>(At, Name, Description)
  , IGqlpInputObject
{
  internal override string Abbr => "In";
  public override string Label => "Input";

  public InputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
