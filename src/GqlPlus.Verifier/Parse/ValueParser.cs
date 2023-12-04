using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

public abstract class ValueParser<T> : IValueParser<T>, Parser<T>.I
  where T : AstValue<T>
{
  protected readonly Parser<FieldKeyAst>.L FieldKey;
  protected readonly Parser<T>.LA ListParser;
  protected readonly Parser<AstObject<T>>.L ObjectParser;

  public Parser<AstKeyValue<T>>.L KeyValueParser { get; }

  public ValueParser(
    Parser<FieldKeyAst>.D fieldKey,
    Parser<AstKeyValue<T>>.D keyValueParser,
    Parser<T>.DA listParser,
    Parser<AstObject<T>>.D objectParser)
  {
    FieldKey = fieldKey;
    KeyValueParser = keyValueParser;
    ListParser = listParser;
    ObjectParser = objectParser;
  }

  public abstract IResult<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;

  public IResult<AstObject<T>> ParseFieldValues(Tokenizer tokens, string label, char last, AstObject<T> fields)
  {
    var result = new AstObject<T>(fields);

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
  Parser<AstKeyValue<T>>.L KeyValueParser { get; }

  IResult<AstObject<T>> ParseFieldValues(Tokenizer tokens, string label, char last, AstObject<T> fields);
}
