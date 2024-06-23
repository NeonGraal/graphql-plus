using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectBaseParser<TObjBase, TObjBaseAst>
  : Parser<TObjBase>.I
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
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
      if (tokens.Take('<')) {
        List<TObjBaseAst> arguments = [];
        IResult<TObjBaseAst> argument = ParseObjectBase(tokens, label, isTypeArgument: true);
        while (argument.Required(arguments.Add)) {
          argument = ParseObjectBase(tokens, label, isTypeArgument: true);
        }

        objBase.BaseArguments = [.. arguments];

        if (!tokens.Take('>')) {
          return tokens.Error(label, "'>' after type argument(s)", objBase);
        } else if (arguments.Count < 1) {
          return tokens.Error(label, "at least one type argument after '<'", objBase);
        }
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
