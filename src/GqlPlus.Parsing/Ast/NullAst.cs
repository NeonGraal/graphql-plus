using GqlPlus.Token;

namespace GqlPlus.Ast;

public record class NullAst(TokenAt At)
{
  public override string ToString() => "NULL";
}
