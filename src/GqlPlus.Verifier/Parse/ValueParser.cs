using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse;

public abstract class ValueParser<T>(
  Parser<FieldKeyAst>.D fieldKey,
  Parser<KeyValue<T>>.D keyValueParser,
  Parser<T>.DA listParser,
  Parser<AstFields<T>>.D objectParser
) : IValueParser<T>, Parser<T>.I
  where T : AstValue<T>
{
  protected Parser<FieldKeyAst>.L FieldKey { get; } = fieldKey;
  protected Parser<T>.LA ListParser { get; } = listParser;
  protected Parser<AstFields<T>>.L ObjectParser { get; } = objectParser;

  public Parser<KeyValue<T>>.L KeyValueParser { get; } = keyValueParser;

  public abstract IResult<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;

  public IResult<AstFields<T>> ParseFieldValues(Tokenizer tokens, string label, char last, AstFields<T> fields)
  {
    ArgumentNullException.ThrowIfNull(tokens);

    var result = new AstFields<T>(fields);

    while (!tokens.Take(last)) {
      var field = KeyValueParser.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error(label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}

public interface IValueParser<T> : Parser<T>.I
  where T : AstValue<T>
{
  Parser<KeyValue<T>>.L KeyValueParser { get; }

  IResult<AstFields<T>> ParseFieldValues(Tokenizer tokens, string label, char last, AstFields<T> fields);
}
