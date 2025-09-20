namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjAlternateAst(At, Name, Description)
{
  internal override string Abbr => "DA";
  public override string Label => "Dual";
}
