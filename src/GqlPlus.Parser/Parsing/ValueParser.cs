using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal abstract class ValueParser<TValue>(
  IParserRepository parsers
) : IValueParser<TValue>
  , Parser<TValue>.I
  where TValue : IGqlpValue<TValue>
{
  protected Parser<IGqlpFieldKey>.L FieldKey { get; } = parsers.ParserFor<IGqlpFieldKey>();
  protected Parser<TValue>.LA ListParser { get; } = parsers.ArrayFor<TValue>();
  protected Parser<IGqlpFields<TValue>>.L ObjectParser { get; } = parsers.ParserFor<IGqlpFields<TValue>>();

  public Parser<KeyValue<TValue>>.L KeyValueParser { get; } = parsers.ParserFor<KeyValue<TValue>>();

  public virtual IResult<TValue> Parse([NotNull] ITokenizer tokens, string label)
  {
    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;
      ITokenAt at = tokens.At;

      IResultArray<TValue> list = ListParser.Parse(tokens, label);
      if (!list.IsEmpty()) {
        return list.Select(NewList(at));
      }

      IResult<IGqlpFields<TValue>> fields = ObjectParser.Parse(tokens, label);
      if (!fields.IsEmpty()) {
        return fields.Select(NewFields(at));
      }
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }

    return default(TValue).Empty();
  }

  protected abstract Func<IEnumerable<TValue>, TValue> NewList(ITokenAt at);
  protected abstract Func<IGqlpFields<TValue>, TValue> NewFields(ITokenAt at);

  public IResult<IGqlpFields<TValue>> ParseFieldValues(
    ITokenizer tokens,
    string label,
    char last,
    IGqlpFields<TValue> fields)
  {
    tokens.ThrowIfNull();

    FieldsAst<TValue> result = new(fields.ToDictionary(p => p.Key, p => p.Value));

#pragma warning disable CA1062 // Validate arguments of public methods
    while (!tokens.Take(last)) {
      IResult<KeyValue<TValue>> field = KeyValueParser.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error<IGqlpFields<TValue>>(label, "a field in object", result);
      }

      tokens.Take(',');
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    return result.Ok<IGqlpFields<TValue>>();
  }
}

internal interface IValueParser<TValue>
  : Parser<TValue>.I
  where TValue : IGqlpValue<TValue>
{
  Parser<KeyValue<TValue>>.L KeyValueParser { get; }

  IResult<IGqlpFields<TValue>> ParseFieldValues(ITokenizer tokens, string label, char last, IGqlpFields<TValue> fields);
}
