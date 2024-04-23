using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseArgument(
  Parser<FieldKeyAst>.D fieldKey,
  Parser<IValueParser<ArgumentAst>, ArgumentAst>.D argument
) : IParserArgument
{
  private readonly Parser<FieldKeyAst>.L _fieldKey = fieldKey;
  private readonly Parser<IValueParser<ArgumentAst>, ArgumentAst>.L _argument = argument;

  public IResult<ArgumentAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (!tokens.Take('(')) {
      return 0.Empty<ArgumentAst>();
    }

    var oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      var at = tokens.At;
      ArgumentAst? value = new(at);

      var fieldKey = _fieldKey.Parse(tokens, label);
      if (fieldKey.IsOk()) {
        return fieldKey.Map(key =>
          tokens.Take(':')
          ? _argument.I.Parse(tokens, "Argument").MapOk(
            item => ParseArgumentMid(tokens, at, new() { [key] = item }),
            () => tokens.Error(label, "a value after field key separator", value))
          : ParseArgumentEnd(tokens, at, key));
      }

      var argValue = _argument.I.Parse(tokens, label);

      return argValue.MapOk(value => ParseArgumentEnd(tokens, at, value), () => argValue);
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private ArgumentAst ParseArgValues(Tokenizer tokens, ArgumentAst initial)
  {
    var at = initial.At;
    var values = new List<ArgumentAst> { initial };
    while (tokens.Take(',')) {
      _argument.I.Parse(tokens, "Argument").Required(values.Add);
    }

    return values.Count > 1
      ? new(at, [.. values])
      : initial;
  }

  private IResult<ArgumentAst> ParseArgumentMid(Tokenizer tokens, TokenAt at, AstFields<ArgumentAst> fields)
  {
    if (tokens.Take(',')) {
      return _argument.I.ParseFieldValues(tokens, "Argument", ')', fields).Select(result => new ArgumentAst(at, result));
    }

    while (!tokens.Take(')')) {
      var field = _argument.I.KeyValueParser.Parse(tokens, "Argument");

      if (!field.Required(value => fields.Add(value.Key, ParseArgValues(tokens, value.Value)))) {
        return field.AsResult<ArgumentAst>();
      }
    }

    return new ArgumentAst(at, fields).Ok();
  }

  private IResult<ArgumentAst> ParseArgumentEnd(Tokenizer tokens, TokenAt at, ArgumentAst value)
  {
    var more = ParseArgValues(tokens, value);
    if (more.Values.Length > 1) {
      return more.Ok();
    }

    var values = new List<ArgumentAst> { value };
    while (_argument.I.Parse(tokens, "Argument").Required(values.Add)) { }

    if (tokens.Take(")")) {
      var argument = values.Count > 1 ? new(at, [.. values]) : value;
      return argument.Ok();
    }

    return tokens.Error("Argument", "a value", more);
  }
}

public interface IParserArgument : Parser<ArgumentAst>.I { }
