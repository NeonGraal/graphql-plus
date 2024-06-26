using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArgument(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<IValueParser<IGqlpArgument>, IGqlpArgument>.D argument
) : IParserArgument
{
  private readonly Parser<IGqlpFieldKey>.L _fieldKey = fieldKey;
  private readonly Parser<IValueParser<IGqlpArgument>, IGqlpArgument>.L _argument = argument;

  public IResult<IGqlpArgument> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (!tokens.Take('(')) {
      return 0.Empty<IGqlpArgument>();
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      TokenAt at = tokens.At;
      IGqlpArgument? value = new ArgumentAst(at);

      IResult<IGqlpFieldKey> fieldKey = _fieldKey.Parse(tokens, label);
      if (fieldKey.IsOk()) {
        return fieldKey.Map<IGqlpArgument>(key =>
          tokens.Take(':')
          ? _argument.I
            .Parse(tokens, "Argument")
            .MapOk(
              item => ParseArgumentMid(tokens, at, new() { [(FieldKeyAst)key] = item }),
              () => tokens.Error(label, "a value after field key separator", value))
          : ParseArgumentEnd(tokens, at, new(key)));
      }

      IResult<IGqlpArgument> argValue = _argument.I.Parse(tokens, label);

      return argValue.MapOk(value => ParseArgumentEnd(tokens, at, (ArgumentAst)value), () => argValue);
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private ArgumentAst ParseArgValues(Tokenizer tokens, ArgumentAst initial)
  {
    TokenAt at = initial.At;
    List<IGqlpArgument> values = [initial];
    while (tokens.Take(',')) {
      _argument.I.Parse(tokens, "Argument").Required(values.Add);
    }

    return values.Count > 1
      ? new(at, values.ArrayOf<ArgumentAst>())
      : initial;
  }

  private IResult<IGqlpArgument> ParseArgumentMid(Tokenizer tokens, TokenAt at, AstFields<IGqlpArgument> fields)
  {
    if (tokens.Take(',')) {
      return _argument.I
        .ParseFieldValues(tokens, "Argument", ')', fields)
        .Select(result => new ArgumentAst(at, result) as IGqlpArgument);
    }

    while (!tokens.Take(')')) {
      IResult<KeyValue<IGqlpArgument>> field = _argument.I.KeyValueParser.Parse(tokens, "Argument");

      if (!field.Required(value => fields.Add((FieldKeyAst)value.Key, ParseArgValues(tokens, (ArgumentAst)value.Value)))) {
        return field.AsResult<IGqlpArgument>();
      }
    }

    return new ArgumentAst(at, fields).Ok<IGqlpArgument>();
  }

  private IResult<IGqlpArgument> ParseArgumentEnd(Tokenizer tokens, TokenAt at, ArgumentAst value)
  {
    IGqlpArgument more = ParseArgValues(tokens, value);
    if (more.Values.Count() > 1) {
      return more.Ok();
    }

    List<IGqlpArgument> values = [value];
    while (_argument.I.Parse(tokens, "Argument").Required(values.Add)) { }

    if (tokens.Take(")")) {
      IGqlpArgument argument = values.Count > 1 ? new(at, values.ArrayOf<ArgumentAst>()) : value;
      return argument.Ok();
    }

    return tokens.Error("Argument", "a value", more);
  }
}

public interface IParserArgument
  : Parser<IGqlpArgument>.I
{ }
