using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectBaseParser<TObjBase, TObjBaseAst, TObjArg, TObjArgAst>(
  Parser<TObjArg>.DA parseArgs
) : Parser<TObjBase>.I
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  private readonly Parser<TObjArg>.LA _parseArgs = parseArgs;

  public IResult<TObjBase> Parse(ITokenizer tokens, string label)

    => ParseObjectBase(tokens, label).AsResult<TObjBase>();

  private IResult<TObjBaseAst> ParseObjectBase(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<TObjBaseAst>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      TObjBaseAst objBase = ObjBase(at, param!, description) with {
        IsTypeParam = true,
      };
      return objBase.Ok();
    }

    at = tokens.At;

    bool hasName = tokens.Identifier(out string? name);
    if (!hasName) {
      if (hasName = tokens.TakeZero()) {
        name = "0";
      } else if (hasName = tokens.TakeAny(out char simple, '^', '*', '_')) {
        name = $"{simple}";
      }
    }

    if (hasName) {
      TObjBaseAst objBase = ObjBase(at, name!, description);
      IResultArray<TObjArg> arguments = _parseArgs.Parse(tokens, label);
      if (!arguments.Optional(values => objBase.BaseArgs = [.. values])) {
        return arguments.AsResult(objBase);
      }

      return objBase.Ok();
    }

    return 0.Empty<TObjBaseAst>();
  }

  protected abstract TObjBaseAst ObjBase(TokenAt at, string type, string description);
}
