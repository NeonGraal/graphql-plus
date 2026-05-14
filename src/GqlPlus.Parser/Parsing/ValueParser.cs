using GqlPlus;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal abstract class ValueParser<TValue>(
  IParserRepository parsers
) : IValueParser<TValue>
  , IParser<TValue>
  where TValue : IAstValue<TValue>
{
  protected ParserOne<IAstFieldKey> FieldKey { get; } = parsers.ParserFor<IAstFieldKey>();
  protected ParserArray<TValue> ListParser { get; } = parsers.ArrayFor<TValue>();
  protected ParserOne<IAstFields<TValue>> ObjectParser { get; } = parsers.ParserFor<IAstFields<TValue>>();

  public ParserOne<KeyValue<TValue>> KeyValueParser { get; } = parsers.ParserFor<KeyValue<TValue>>();

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

      IResult<IAstFields<TValue>> fields = ObjectParser.Parse(tokens, label);
      if (!fields.IsEmpty()) {
        return fields.Select(NewFields(at));
      }
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }

    return default(TValue).Empty();
  }

  protected abstract Func<IEnumerable<TValue>, TValue> NewList(ITokenAt at);
  protected abstract Func<IAstFields<TValue>, TValue> NewFields(ITokenAt at);

  public IResult<IAstFields<TValue>> ParseFieldValues(
    ITokenizer tokens,
    string label,
    char last,
    IAstFields<TValue> fields)
  {
    tokens.ThrowIfNull();

    FieldsAst<TValue> result = new(fields.ToDictionary(p => p.Key, p => p.Value));

#pragma warning disable CA1062 // Validate arguments of public methods
    while (!tokens.Take(last)) {
      IResult<KeyValue<TValue>> field = KeyValueParser.Parse(tokens, label);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error<IAstFields<TValue>>(label, "a field in object", result);
      }

      tokens.Take(',');
    }
#pragma warning restore CA1062 // Validate arguments of public methods

    return result.Ok<IAstFields<TValue>>();
  }
}

internal interface IValueParser<TValue>
  : IParser<TValue>
  where TValue : IAstValue<TValue>
{
  ParserOne<KeyValue<TValue>> KeyValueParser { get; }

  IResult<IAstFields<TValue>> ParseFieldValues(ITokenizer tokens, string label, char last, IAstFields<TValue> fields);
}

internal interface IValueParserFactories<TValue>
  where TValue : IAstValue<TValue>
{
  ValueParser<TValue> Value(IParserRepository repo);
  ValueKeyValueParser<TValue> ValueKey(IParserRepository repo);
  ValueListParser<TValue> ValueList(IParserRepository repo);
  ValueObjectParser<TValue> ValueObject(IParserRepository repo);
}
