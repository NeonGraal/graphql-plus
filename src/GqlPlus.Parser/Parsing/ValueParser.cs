using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public abstract class ValueParser<TValue>(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<KeyValue<TValue>>.D keyValueParser,
  Parser<TValue>.DA listParser,
  Parser<AstFields<TValue>>.D objectParser
) : IValueParser<TValue>
  , Parser<TValue>.I
  where TValue : IGqlpValue<TValue>
{
  protected Parser<IGqlpFieldKey>.L FieldKey { get; } = fieldKey;
  protected Parser<TValue>.LA ListParser { get; } = listParser;
  protected Parser<AstFields<TValue>>.L ObjectParser { get; } = objectParser;

  public Parser<KeyValue<TValue>>.L KeyValueParser { get; } = keyValueParser;

  public abstract IResult<TValue> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;

  public IResult<AstFields<TValue>> ParseFieldValues(Tokenizer tokens, string label, char last, AstFields<TValue> fields)
  {
    ArgumentNullException.ThrowIfNull(tokens);

    AstFields<TValue> result = new(fields);

    while (!tokens.Take(last)) {
      IResult<KeyValue<TValue>> field = KeyValueParser.Parse(tokens, label);
      if (!field.Required(value => result.Add((FieldKeyAst)value.Key, value.Value))) {
        return tokens.Error(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}

public interface IValueParser<TValue>
  : Parser<TValue>.I
  where TValue : IGqlpValue<TValue>
{
  Parser<KeyValue<TValue>>.L KeyValueParser { get; }

  IResult<AstFields<TValue>> ParseFieldValues(Tokenizer tokens, string label, char last, AstFields<TValue> fields);
}
