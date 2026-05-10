using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ValueObjectParser<TValue>(
  IParserRepository parsers
) : IParser<IAstFields<TValue>>
  where TValue : IAstValue<TValue>
{
  private readonly ParserOne<KeyValue<TValue>> _field = parsers.ParserFor<KeyValue<TValue>>();

  public IResult<IAstFields<TValue>> Parse([NotNull] ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    if (!tokens.Take('{')) {
      return default(IAstFields<TValue>).Empty();
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    FieldsAst<TValue> result = [];
    while (!tokens.Take('}')) {
      IResult<KeyValue<TValue>> field = _field.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error<IAstFields<TValue>>(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok<IAstFields<TValue>>();
  }

  internal static ValueObjectParser<TValue> Factory(IParserRepository p) => new(p);
}
