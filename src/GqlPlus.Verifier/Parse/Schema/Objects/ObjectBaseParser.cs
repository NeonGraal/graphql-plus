using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal abstract class ObjectBaseParser<TObjBase>
  : Parser<TObjBase>.I
  where TObjBase : AstObjectBase<TObjBase>
{
  public IResult<TObjBase> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => ParseObjectBase(tokens, label, false);

  private IResult<TObjBase> ParseObjectBase<TContext>(TContext tokens, string label, bool isTypeArgument)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    if (!tokens.Prefix('$', out var param, out var at)) {
      return tokens.Error<TObjBase>(label, "identifier after '$'");
    }

    if (param is not null) {
      var objBase = ObjBase(at, param, description) with {
        IsTypeParameter = true,
      };
      return objBase.Ok();
    }

    at = tokens.At;

    if (tokens.Identifier(out var name)) {
      var objBase = ObjBase(at, name, description);
      if (tokens.Take('<')) {
        var arguments = new List<TObjBase>();
        var argument = ParseObjectBase(tokens, label, isTypeArgument: true);
        while (argument.Required(arguments.Add)) {
          argument = ParseObjectBase(tokens, label, isTypeArgument: true);
        }

        objBase.Arguments = [.. arguments];

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

    return 0.Empty<TObjBase>();
  }

  protected abstract TObjBase ObjBase(TokenAt at, string type, string description);
  protected abstract IResult<TObjBase> TypeEnumValue<TContext>(TContext tokens, TObjBase objBase)
      where TContext : Tokenizer;
}
