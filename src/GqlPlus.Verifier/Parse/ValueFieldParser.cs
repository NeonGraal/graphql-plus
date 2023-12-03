using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

public abstract class ValueFieldParser<T> : Parser<Field<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<FieldKeyAst>.L _key;
  private readonly Parser<T>.L _value;

  protected ValueFieldParser(
    Parser<FieldKeyAst>.D key,
    Parser<T>.D value)
  {
    _key = key;
    _value = value;
  }

  public abstract string Label { get; }

  public IResult<Field<T>> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var fieldKey = _key.Parse(tokens);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<Field<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<Field<T>>(Label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<Field<T>>(Label, "key before ':'");
    }

    var fieldValue = _value.Parse(tokens);
    return fieldValue.SelectOk(
      value => new Field<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<Field<T>>()); // Not Covered
  }
}

public record struct Field<T>(FieldKeyAst Key, T Value)
  where T : AstValue<T>;
