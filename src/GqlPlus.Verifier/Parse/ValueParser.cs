﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

public abstract class ValueParser<T>(
  Parser<FieldKeyAst>.D fieldKey,
  Parser<AstKeyValue<T>>.D keyValueParser,
  Parser<T>.DA listParser,
  Parser<AstObject<T>>.D objectParser
) : IValueParser<T>, Parser<T>.I
  where T : AstValue<T>
{
  protected readonly Parser<FieldKeyAst>.L FieldKey = fieldKey;
  protected readonly Parser<T>.LA ListParser = listParser;
  protected readonly Parser<AstObject<T>>.L ObjectParser = objectParser;

  public Parser<AstKeyValue<T>>.L KeyValueParser { get; } = keyValueParser;

  public abstract IResult<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;

  public IResult<AstObject<T>> ParseFieldValues(Tokenizer tokens, string label, char last, AstObject<T> fields)
  {
    var result = new AstObject<T>(fields);

    while (!tokens.Take(last)) {
      var field = KeyValueParser.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}

public interface IValueParser<T> : Parser<T>.I
  where T : AstValue<T>
{
  Parser<AstKeyValue<T>>.L KeyValueParser { get; }

  IResult<AstObject<T>> ParseFieldValues(Tokenizer tokens, string label, char last, AstObject<T> fields);
}
