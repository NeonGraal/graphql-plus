using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputArgAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
  , IEquatable<InputArgAst>
  , IGqlpInputArg
{
  public InputArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  string IGqlpInputArg.Input => Name;
  IGqlpDualArg IGqlpToDual<IGqlpDualArg>.ToDual => ToDual();

  public DualArgAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
    };
}
