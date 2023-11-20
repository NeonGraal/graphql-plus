using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

public abstract class ParseValues<T> : IParser<Field<T>>, IParser<T>
  where T : AstValues<T>
{
  protected readonly IParser<FieldKeyAst> _fieldKey;

  public ParseValues(
    IParser<FieldKeyAst> fieldKey)
    => _fieldKey = fieldKey;

  protected abstract string Label { get; }

  public abstract IResult<T> Parse(Tokenizer tokens);

  protected IResult<Field<T>> ParseField(Tokenizer tokens, string label)
  {
    var fieldKey = _fieldKey.Parse(tokens);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<Field<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<Field<T>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<Field<T>>(label, "key before ':'");
    }

    var fieldValue = Parse(tokens);
    return fieldValue.SelectOk(
      value => new Field<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<Field<T>>());
  }

  IResult<Field<T>> IParser<Field<T>>.Parse(Tokenizer tokens)
    => ParseField(tokens, Label);
}

public record struct Field<T>(FieldKeyAst Key, T Value)
  where T : AstValues<T>;
