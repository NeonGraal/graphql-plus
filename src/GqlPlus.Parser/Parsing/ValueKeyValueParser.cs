using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ValueKeyValueParser<TValue>(
  IParserRepository parsers
) : Parser<KeyValue<TValue>>.I
  where TValue : IAstValue<TValue>
{
  private readonly Parser<IAstFieldKey>.L _key = parsers.ParserFor<IAstFieldKey>();
  private readonly Parser<TValue>.L _value = parsers.ParserFor<TValue>();

  public IResult<KeyValue<TValue>> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();

    IResult<IAstFieldKey> fieldKey = _key.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<KeyValue<TValue>>();
    }

#pragma warning disable CA1062 // Validate arguments of public methods
    if (!tokens.Take(':')) {
      return tokens.Error<KeyValue<TValue>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
#pragma warning restore CA1062 // Validate arguments of public methods
      return tokens.Error<KeyValue<TValue>>(label, "key before ':'");
    }

    IResult<TValue> fieldValue = _value.Parse(tokens, label);
    return fieldValue.SelectOk(
      value => new KeyValue<TValue>(fieldKey.Required(), value),
      () => tokens.Error<KeyValue<TValue>>(label, "value after ':'"));
  }
}

public record struct KeyValue<TValue>(
  IAstFieldKey Key,
  TValue Value
) where TValue : IAstValue<TValue>;
