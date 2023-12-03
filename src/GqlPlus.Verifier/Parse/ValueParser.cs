﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

public abstract class ValueParser<T> : IValueParser<T>, Parser<T>.I
  where T : AstValue<T>
{
  protected readonly Parser<FieldKeyAst>.L FieldKey;
  protected readonly Parser<AstKeyValue<T>>.L KeyValueParser;
  protected readonly Parser<T>.LA ListParser;
  protected readonly Parser<AstObject<T>>.L ObjectParser;

  public ParserProxy<AstKeyValue<T>, Tokenizer> FieldIParser { get; }

  public ValueParser(
    Parser<FieldKeyAst>.D fieldKey,
    Parser<AstKeyValue<T>>.D keyValueParser,
    Parser<T>.DA listParser,
    Parser<AstObject<T>>.D objectParser)
  {
    FieldKey = fieldKey;
    KeyValueParser = keyValueParser;
    ListParser = listParser;
    ObjectParser = objectParser;

    FieldIParser = new(ParseField);
  }

  protected abstract string Label { get; }

  public IResult<T> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
    => Parse(tokens, Label);

  public abstract IResult<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;

  public IResult<AstKeyValue<T>> ParseField(Tokenizer tokens)
  {
    var fieldKey = FieldKey.Parse(tokens, Label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<AstKeyValue<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<AstKeyValue<T>>(Label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<AstKeyValue<T>>(Label, "key before ':'");
    }

    var fieldValue = Parse(tokens);
    return fieldValue.SelectOk(
      value => new AstKeyValue<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<AstKeyValue<T>>()); // Not Covered
  }

  protected AstObject<T> NewObject(AstObject<T>? fields = default)
    => fields is null ? new() : new(fields);

  public IResult<AstObject<T>> ParseFieldValues(Tokenizer tokens, char last, AstObject<T> fields)
  {
    var result = NewObject(fields);

    while (!tokens.Take(last)) {
      var field = ParseField(tokens);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error(Label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }

  protected IResultArray<T> ParseList(Tokenizer tokens)
  {
    var list = new List<T>();

    if (!tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(']')) {
      if (!Parse(tokens).Required(list.Add)) {
        return tokens.ErrorArray(Label, "a value in list", list);
      }

      tokens.Take(',');
    }

    return list.OkArray();
  }

  protected IResult<AstObject<T>> ParseObject(Tokenizer tokens)
    => tokens.Take('{')
      ? ParseFieldValues(tokens, '}', NewObject())
      : default(AstObject<T>).Empty();
}

public interface IValueParser<T> : IParser<T>
  where T : AstValue<T>
{
  ParserProxy<AstKeyValue<T>, Tokenizer> FieldIParser { get; }

  IResult<AstKeyValue<T>> ParseField(Tokenizer tokens);
  IResult<AstObject<T>> ParseFieldValues(Tokenizer tokens, char last, AstObject<T> fields);
}
