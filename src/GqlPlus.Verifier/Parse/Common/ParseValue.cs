using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

public abstract class ParseValue<T> : IParserValue<T>, IParser<Field<T>>
  where T : AstValue<T>
{
  protected readonly IParser<FieldKeyAst> _fieldKey;

  public ParseValue(
    IParser<FieldKeyAst> fieldKey)
    => _fieldKey = fieldKey.ThrowIfNull();

  protected abstract string Label { get; }

  public abstract IResult<T> Parse(Tokenizer tokens);

  public IResult<Field<T>> ParseField(Tokenizer tokens)
  {
    var fieldKey = _fieldKey.Parse(tokens);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<Field<T>>();
    }

    if (!tokens.Take(':')) {
      return tokens.Error<Field<T>>(Label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return tokens.Error<Field<T>>(Label, "key before ':'");
    }

    var fieldValue = Parse(tokens);
    return fieldValue.SelectOk(
      value => new Field<T>(fieldKey.Required(), value),
      () => fieldValue.AsResult<Field<T>>());
  }

  IResult<Field<T>> IParser<Field<T>>.Parse(Tokenizer tokens)
    => ParseField(tokens);

  protected abstract AstValue<T>.ObjectAst NewObject(AstValue<T>.ObjectAst? fields = default);

  public IResult<AstValue<T>.ObjectAst> ParseFieldValues(Tokenizer tokens, char last, AstValue<T>.ObjectAst fields)
  {
    var result = NewObject(fields);

    while (!tokens.Take(last)) {
      var field = ParseField(tokens);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error("Argument", "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }

  protected IResultArray<T> ParseList(Tokenizer tokens)
  {
    var list = new List<T>();

    if (!tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(']')) {
      if (!Parse(tokens).Required(list.Add)) {
        return tokens.ErrorArray("Argument", "a value in list", list);
      }

      tokens.Take(',');
    }

    return list.OkArray();
  }

  protected IResult<AstValue<T>.ObjectAst> ParseObject(Tokenizer tokens)
    => tokens.Take('{')
      ? ParseFieldValues(tokens, '}', NewObject())
      : default(AstValue<T>.ObjectAst).Empty();
}

public record struct Field<T>(FieldKeyAst Key, T Value)
  where T : AstValue<T>;

public interface IParserValue<T> : IParser<T>
  where T : AstValue<T>
{
  IResult<Field<T>> ParseField(Tokenizer tokens);
  IResult<AstValue<T>.ObjectAst> ParseFieldValues(Tokenizer tokens, char last, AstValue<T>.ObjectAst fields);
}
