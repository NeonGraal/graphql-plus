using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public class ValueKeyValueParser<TValue>(
  Parser<IGqlpFieldKey>.D key,
  Parser<TValue>.D value
) : Parser<KeyValue<TValue>>.I
  where TValue : IGqlpValue<TValue>
{
  private readonly Parser<IGqlpFieldKey>.L _key = key;
  private readonly Parser<TValue>.L _value = value;

  public IResult<KeyValue<TValue>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    IResult<IGqlpFieldKey> fieldKey = _key.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<KeyValue<TValue>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<KeyValue<TValue>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<KeyValue<TValue>>(label, "key before ':'");
    }

    IResult<TValue> fieldValue = _value.Parse(tokens, label);
    return fieldValue.SelectOk(
      value => new KeyValue<TValue>(fieldKey.Required(), value),
      () => fieldValue.AsResult<KeyValue<TValue>>()); // Not Covered
  }
}

public record struct KeyValue<TValue>(
  IGqlpFieldKey Key,
  TValue Value
) where TValue : IGqlpValue<TValue>;
