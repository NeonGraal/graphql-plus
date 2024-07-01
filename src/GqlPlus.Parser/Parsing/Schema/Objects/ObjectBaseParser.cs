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
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  private readonly Parser<TObjArg>.LA _parseArgs = parseArgs;

  public IResult<TObjBase> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => ParseObjectBase(tokens, label, false).AsResult<TObjBase>();

  private IResult<TObjBaseAst> ParseObjectBase<TContext>(TContext tokens, string label, bool isTypeArgument)
    where TContext : Tokenizer
  {
    tokens.String(out string? description);
    if (!tokens.Prefix('$', out string? param, out TokenAt? at)) {
      return tokens.Error<TObjBaseAst>(label, "identifier after '$'");
    }

    if (param is not null) {
      TObjBaseAst objBase = ObjBase(at, param, description) with {
        IsTypeParameter = true,
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
      TObjBaseAst objBase = ObjBase(at, name, description);
      IResultArray<TObjArg> arguments = _parseArgs.Parse(tokens, label);
      if (!arguments.Optional(values => objBase.BaseArguments = [.. values])) {
        return arguments.AsResult(objBase);
      } else if (isTypeArgument) {
        return TypeEnumValue(tokens, objBase);
      }

      return objBase.Ok();
    }

    return 0.Empty<TObjBaseAst>();
  }

  protected abstract TObjBaseAst ObjBase(TokenAt at, string type, string description);
  protected abstract IResult<TObjBaseAst> TypeEnumValue<TContext>(TContext tokens, TObjBaseAst objBase)
      where TContext : Tokenizer;
}
