namespace GqlPlus.Verifier.Ast;

public record class NullAst(TokenAt At)
{
  public override string ToString() => "NULL";
}
