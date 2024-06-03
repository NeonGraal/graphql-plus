using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualBase
  : ObjectBaseParser<IGqlpDualBase, DualBaseAst>
{
  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<DualBaseAst> TypeEnumValue<TContext>(TContext tokens, DualBaseAst objBase)
    => objBase.Ok();
}
