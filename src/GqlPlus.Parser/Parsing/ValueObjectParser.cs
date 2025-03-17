using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public class ValueObjectParser<TValue>(
  Parser<KeyValue<TValue>>.D field
) : Parser<IGqlpFields<TValue>>.I
  where TValue : IGqlpValue<TValue>
{
  private readonly Parser<KeyValue<TValue>>.L _field = field;

  public IResult<IGqlpFields<TValue>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    if (!tokens.Take('{')) {
      return 0.Empty<IGqlpFields<TValue>>();
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    AstFields<TValue> result = [];
    while (!tokens.Take('}')) {
      IResult<KeyValue<TValue>> field = _field.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error<IGqlpFields<TValue>>(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok<IGqlpFields<TValue>>();
  }
}
