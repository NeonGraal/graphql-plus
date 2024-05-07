using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public class ValueKeyValueParser<T>(
  Parser<IGqlpFieldKey>.D key,
  Parser<T>.D value
) : Parser<KeyValue<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<IGqlpFieldKey>.L _key = key;
  private readonly Parser<T>.L _value = value;

  public IResult<KeyValue<T>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    IResult<IGqlpFieldKey> fieldKey = _key.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<KeyValue<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<KeyValue<T>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<KeyValue<T>>(label, "key before ':'");
    }

    IResult<T> fieldValue = _value.Parse(tokens, label);
    return fieldValue.SelectOk(
      value => new KeyValue<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<KeyValue<T>>()); // Not Covered
  }
}

public record struct KeyValue<T>(IGqlpFieldKey Key, T Value)
  where T : AstValue<T>;
