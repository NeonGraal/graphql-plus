using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjBase<IGqlpInputBase>(At, Name, Description)
  , IEquatable<InputBaseAst>
  , IGqlpInputBase
{
  public InputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  string IGqlpInputBase.Input => Name;
  IGqlpDualBase IGqlpToDual.ToDual => ToDual();

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      BaseArguments = [.. BaseArguments.Select(a => a.ToDual)],
    };
}
