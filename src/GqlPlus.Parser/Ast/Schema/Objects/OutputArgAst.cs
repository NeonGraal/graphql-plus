using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
  , IGqlpOutputArg
{
  public OutputArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  public DualArgAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
    };

  IGqlpDualArg IGqlpToDual<IGqlpDualArg>.ToDual => ToDual();
}
