using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public abstract class ValueParser<TValue>(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<KeyValue<TValue>>.D keyValueParser,
  Parser<TValue>.DA listParser,
  Parser<IGqlpFields<TValue>>.D objectParser
) : IValueParser<TValue>
  , Parser<TValue>.I
  where TValue : IGqlpValue<TValue>
{
  protected Parser<IGqlpFieldKey>.L FieldKey { get; } = fieldKey;
  protected Parser<TValue>.LA ListParser { get; } = listParser;
  protected Parser<IGqlpFields<TValue>>.L ObjectParser { get; } = objectParser;

  public Parser<KeyValue<TValue>>.L KeyValueParser { get; } = keyValueParser;

  public abstract IResult<TValue> Parse(ITokenizer tokens, string label);

  public IResult<IGqlpFields<TValue>> ParseFieldValues(ITokenizer tokens, string label, char last, IGqlpFields<TValue> fields)
  {
    tokens.ThrowIfNull();

    AstFields<TValue> result = new(fields);

#pragma warning disable CA1062 // Validate arguments of public methods
    while (!tokens.Take(last)) {
      IResult<KeyValue<TValue>> field = KeyValueParser.Parse(tokens, label);
      if (!field.Required(value => result.Add((FieldKeyAst)value.Key, value.Value))) {
        return tokens.Error<IGqlpFields<TValue>>(label, "a field in object", result);
      }

      tokens.Take(',');
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    return result.Ok<IGqlpFields<TValue>>();
  }
}

public interface IValueParser<TValue>
  : Parser<TValue>.I
  where TValue : IGqlpValue<TValue>
{
  Parser<KeyValue<TValue>>.L KeyValueParser { get; }

  IResult<IGqlpFields<TValue>> ParseFieldValues(ITokenizer tokens, string label, char last, IGqlpFields<TValue> fields);
}
