using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>(At, Name, Description)
  , IGqlpInputObject
{
  internal override string Abbr => "In";
  public override string Label => "Input";

  public InputDeclAst(ITokenAt at, string name)
    : this(at, name, "")
  { }
}
