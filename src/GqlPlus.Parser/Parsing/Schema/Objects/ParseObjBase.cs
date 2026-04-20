using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjBase(
  IParserRepository parsers
) : Parser<IAstObjBase>.I
{
  private readonly Parser<IAstTypeArg>.LA _parseArgs = parsers.ArrayFor<IAstTypeArg>();

  public IResult<IAstObjBase> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<IAstObjBase>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      IAstObjBase objBase = new ObjBaseAst(at, param!, description) {
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
      IResultArray<IAstTypeArg> arguments = _parseArgs.Parse(tokens, label);
      if (!arguments.Optional(values => objBase.Args = [.. values])) {
        return arguments.AsResult<IAstObjBase>(objBase);
      }

      return objBase.Ok<IAstObjBase>();
    }

    return default(IAstObjBase).Empty();
  }
}
