using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<InputFieldAst, IGqlpInputBase>(At, Name, Description)
  , IGqlpInputObject
{
  internal override string Abbr => "In";
  public override string Label => "Input";

  IEnumerable<IGqlpInputField> IGqlpObject<IGqlpInputField, IGqlpInputBase>.Fields => Fields;
  IEnumerable<IGqlpAlternate<IGqlpInputBase>> IGqlpObject<IGqlpInputField, IGqlpInputBase>.Alternates
    => Alternates.Cast<IGqlpAlternate<IGqlpInputBase>>();
  IGqlpInputBase? IGqlpType<IGqlpInputBase>.Parent => Parent;

  public InputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
