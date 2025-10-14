using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjBase(
  Parser<IGqlpObjTypeArg>.DA parseArgs
) : Parser<IGqlpObjBase>.I
{
  private readonly Parser<IGqlpObjTypeArg>.LA _parseArgs = parseArgs;

  public IResult<IGqlpObjBase> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<IGqlpObjBase>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      IGqlpObjBase objBase = new ObjBaseAst(at, param!, description) {
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
      ObjBaseAst objBase = new(at, name!, description);
      IResultArray<IGqlpObjTypeArg> arguments = _parseArgs.Parse(tokens, label);
      if (!arguments.Optional(values => objBase.Args = [.. values])) {
        return arguments.AsResult<IGqlpObjBase>(objBase);
      }

      return objBase.Ok<IGqlpObjBase>();
    }

    return default(IGqlpObjBase).Empty();
  }
}
