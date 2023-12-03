using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

public abstract class ValueKeyValueParser<T> : Parser<AstKeyValue<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<FieldKeyAst>.L _key;
  private readonly Parser<T>.L _value;

  protected ValueKeyValueParser(
    Parser<FieldKeyAst>.D key,
    Parser<T>.D value)
  {
    _key = key;
    _value = value;
  }

  public abstract string Label { get; }

  public IResult<AstKeyValue<T>> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var fieldKey = _key.Parse(tokens);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<AstKeyValue<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<AstKeyValue<T>>(Label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<AstKeyValue<T>>(Label, "key before ':'");
    }

    var fieldValue = _value.Parse(tokens);
    return fieldValue.SelectOk(
      value => new AstKeyValue<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<AstKeyValue<T>>()); // Not Covered
  }
}
