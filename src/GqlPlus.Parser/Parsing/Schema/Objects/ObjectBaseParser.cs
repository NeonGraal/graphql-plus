using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectBaseParser<TObjBase, TObjBaseAst>(
  Parser<IGqlpObjArg>.DA parseArgs
) : Parser<TObjBase>.I
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase, TObjBase
{
  private readonly Parser<IGqlpObjArg>.LA _parseArgs = parseArgs;

  public IResult<TObjBase> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<TObjBase>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      TObjBase objBase = ObjBase(at, param!, description) with {
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
      IResultArray<IGqlpObjArg> arguments = _parseArgs.Parse(tokens, label);
      if (!arguments.Optional(values => objBase.Args = [.. values])) {
        return arguments.AsResult<TObjBase>(objBase);
      }

      return objBase.Ok<TObjBase>();
    }

    return 0.Empty<TObjBase>();
  }

  protected abstract TObjBaseAst ObjBase(TokenAt at, string type, string description);
}
