using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

[ExcludeFromCodeCoverage]
public class ValueKeyValueParser<T> : Parser<KeyValue<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<FieldKeyAst>.L _key;
  private readonly Parser<T>.L _value;

  public ValueKeyValueParser(
    Parser<FieldKeyAst>.D key,
    Parser<T>.D value)
  {
    _key = key;
    _value = value;
  }

  public IResult<KeyValue<T>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var fieldKey = _key.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<KeyValue<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<KeyValue<T>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<KeyValue<T>>(label, "key before ':'");
    }

    var fieldValue = _value.Parse(tokens, label);
    return fieldValue.SelectOk(
      value => new KeyValue<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<KeyValue<T>>()); // Not Covered
  }
}

public record struct KeyValue<T>(FieldKeyAst Key, T Value)
  where T : AstValue<T>;
