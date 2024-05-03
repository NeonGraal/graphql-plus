using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseDualBase
  : ObjectBaseParser<DualBaseAst>
{
  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<DualBaseAst> TypeEnumValue<TContext>(TContext tokens, DualBaseAst objBase)
    => objBase.Ok();
}
