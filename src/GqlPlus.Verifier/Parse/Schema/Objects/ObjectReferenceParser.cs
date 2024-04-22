﻿using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal abstract class ObjectReferenceParser<R> : Parser<R>.I
  where R : AstReference<R>
{
  public IResult<R> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => ParseReference(tokens, label, false);

  private IResult<R> ParseReference<TContext>(TContext tokens, string label, bool isTypeArgument)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    if (!tokens.Prefix('$', out var param, out var at)) {
      return tokens.Error<R>(label, "identifier after '$'");
    }

    if (param is not null) {
      var reference = Reference(at, param, description) with {
        IsTypeParameter = true,
      };
      return reference.Ok();
    }

    at = tokens.At;

    if (tokens.Identifier(out var name)) {
      var reference = Reference(at, name, description);
      if (tokens.Take('<')) {
        var arguments = new List<R>();
        var referenceArgument = ParseReference(tokens, label, isTypeArgument: true);
        while (referenceArgument.Required(arguments.Add)) {
          referenceArgument = ParseReference(tokens, label, isTypeArgument: true);
        }

        reference.Arguments = [.. arguments];

        if (!tokens.Take('>')) {
          return tokens.Error(label, "'>' after type argument(s)", reference);
        } else if (arguments.Count < 1) {
          return tokens.Error(label, "at least one type argument after '<'", reference);
        }
      } else if (isTypeArgument) {
        return TypeEnumValue(tokens, reference);
      }

      return reference.Ok();
    }

    return 0.Empty<R>();
  }

  protected abstract R Reference(TokenAt at, string type, string description);
  protected abstract IResult<R> TypeEnumValue<TContext>(TContext tokens, R reference)
      where TContext : Tokenizer;
}
