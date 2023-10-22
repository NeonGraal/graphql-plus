namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class EnumLabelAst(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<EnumLabelAst>
{
  internal override string Abbr => "EL";

  public EnumLabelAst(ParseAt at, string name)
    : this(at, name, "") { }
}
