using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

[ExcludeFromCodeCoverage]
public class ValueKeyValueParser<T> : Parser<AstKeyValue<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<FieldKeyAst>.L _key;
  private readonly Parser<T>.L _value;

  public ValueKeyValueParser(
    Parser<FieldKeyAst>.D key,
    Parser<T>.D value)
  {
    _key = key;
    _value = value;
  }

  public IResult<AstKeyValue<T>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var fieldKey = _key.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<AstKeyValue<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<AstKeyValue<T>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<AstKeyValue<T>>(label, "key before ':'");
    }

    var fieldValue = _value.Parse(tokens, label);
    return fieldValue.SelectOk(
      value => new AstKeyValue<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<AstKeyValue<T>>()); // Not Covered
  }
}
