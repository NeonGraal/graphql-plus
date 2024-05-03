using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseInputBase
  : ObjectBaseParser<InputBaseAst>
{
  protected override InputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<InputBaseAst> TypeEnumValue<TContext>(TContext tokens, InputBaseAst objBase)
    => objBase.Ok();
}
