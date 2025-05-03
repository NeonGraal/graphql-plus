using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputBaseAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjBase<IGqlpInputArg>(At, Name, Description)
  , IEquatable<InputBaseAst>
  , IGqlpInputBase
{
  public InputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  string IGqlpInputNamed.Input => Name;
  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
    };
}
