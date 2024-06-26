using GqlPlus.Token;

namespace GqlPlus.Ast;

internal record class NullAst(TokenAt At)
{
  public override string ToString() => "NULL";
}
