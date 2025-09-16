namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
{
  public InputArgAst(ITokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";
}
