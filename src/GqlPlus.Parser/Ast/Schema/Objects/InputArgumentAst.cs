using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
  , IEquatable<InputArgAst>
  , IGqlpInputArg
{
  public InputArgAst(ITokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  string IGqlpInputNamed.Input => Name;
  IGqlpDualArg IGqlpToDual<IGqlpDualArg>.ToDual => ToDual();

  public DualArgAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
    };
}
