using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public class ValueObjectParser<T>(
  Parser<KeyValue<T>>.D field
) : Parser<AstFields<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<KeyValue<T>>.L _field = field;

  public IResult<AstFields<T>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    AstFields<T> result = [];

    if (!tokens.Take('{')) {
      return result.Empty();
    }

    while (!tokens.Take('}')) {
      IResult<KeyValue<T>> field = _field.Parse(tokens, label);
      if (!field.Required(value => result.Add((FieldKeyAst)value.Key, value.Value))) {
        return tokens.Error(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}
