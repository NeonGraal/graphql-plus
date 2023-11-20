using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

public abstract class ParseValues<T> : IParser<Field<T>>, IParser<T>
  where T : AstValues<T>
{
  protected readonly IParser<FieldKeyAst> _fieldKey;

  public ParseValues(
    IParser<FieldKeyAst> fieldKey)
    => _fieldKey = fieldKey;

  public abstract IResult<T> Parse(Tokenizer tokens, string label);

  protected IResult<Field<T>> ParseField(Tokenizer tokens, string label)
  {
    var fieldKey = _fieldKey.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<Field<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<Field<T>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<Field<T>>(label, "key before ':'");
    }

    var fieldValue = Parse(tokens, label);
    return fieldValue.SelectOk(
      value => new Field<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<Field<T>>());
  }

  IResult<Field<T>> IParser<Field<T>>.Parse(Tokenizer tokens, string label)
    => ParseField(tokens, label);
}

public record struct Field<T>(FieldKeyAst Key, T Value)
  where T : AstValues<T>;
