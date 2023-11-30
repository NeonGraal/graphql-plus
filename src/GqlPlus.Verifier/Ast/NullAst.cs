namespace GqlPlus.Verifier.Ast;

public record class NullAst(ParseAt At)
{
  public override string ToString() => "NULL";
}
