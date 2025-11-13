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

  public IResult<IGqlpFields<TValue>> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    if (!tokens.Take('{')) {
      return default(IGqlpFields<TValue>).Empty();
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    FieldsAst<TValue> result = [];
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
