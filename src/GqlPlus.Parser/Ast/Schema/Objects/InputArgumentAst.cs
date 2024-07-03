using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputArgumentAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjArgument(At, Name, Description)
  , IEquatable<InputArgumentAst>
  , IGqlpInputArgument
{
  public InputArgumentAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  string IGqlpInputArgument.Input => Name;
  IGqlpDualArgument IGqlpToDual<IGqlpDualArgument>.ToDual => ToDual();

  public DualArgumentAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
    };
}
