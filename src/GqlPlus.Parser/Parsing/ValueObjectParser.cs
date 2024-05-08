using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public class ValueObjectParser<TValue>(
  Parser<KeyValue<TValue>>.D field
) : Parser<AstFields<TValue>>.I
  where TValue : IGqlpValue<TValue>
{
  private readonly Parser<KeyValue<TValue>>.L _field = field;

  public IResult<AstFields<TValue>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    AstFields<TValue> result = [];

    if (!tokens.Take('{')) {
      return result.Empty();
    }

    while (!tokens.Take('}')) {
      IResult<KeyValue<TValue>> field = _field.Parse(tokens, label);
      if (!field.Required(value => result.Add((FieldKeyAst)value.Key, value.Value))) {
        return tokens.Error(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}
