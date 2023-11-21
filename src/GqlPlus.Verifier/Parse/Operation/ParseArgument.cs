using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse.Common;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseArgument : IParserArgument
{
  protected readonly IParser<FieldKeyAst> _fieldKey;
  protected readonly IParserValue<ArgumentAst> _argument;

  public ParseArgument(
    IParser<FieldKeyAst> fieldKey,
    IParserValue<ArgumentAst> argument)
  {
    _fieldKey = fieldKey.ThrowIfNull();
    _argument = argument.ThrowIfNull();
  }

  public IResult<ArgumentAst> Parse<TContext>(TContext tokens)
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

      var fieldKey = _fieldKey.Parse(tokens);
      if (fieldKey.IsOk()) {
        return fieldKey.Map(key =>
          tokens.Take(':')
          ? _argument.Parse(tokens).MapOk(
            item => ParseArgumentMid(tokens, at, new() { [key] = item }),
            () => tokens.Error("Argument", "a value after field key separator", value))
          : ParseArgumentEnd(tokens, at, key));
      }

      var argValue = _argument.Parse(tokens);

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
      _argument.Parse(tokens).Required(values.Add);
    }

    return values.Count > 1
      ? new(at, values.ToArray())
      : initial;
  }

  private IResult<ArgumentAst> ParseArgumentMid(Tokenizer tokens, ParseAt at, ArgumentAst.ObjectAst fields)
  {
    if (tokens.Take(',')) {
      return _argument.ParseFieldValues(tokens, ')', fields).Select(result => new ArgumentAst(at, result));
    }

    while (!tokens.Take(')')) {
      var field = _argument.ParseField(tokens);

      if (!field.Required(value => fields.Add(value.Key, ParseArgValues(tokens, value.Value)))) {
        return field.AsResult<ArgumentAst>();
      }
    }

    return new ArgumentAst(at, fields).Ok();
  }

  private IResult<ArgumentAst> ParseArgumentEnd(Tokenizer tokens, ParseAt at, ArgumentAst value)
  {
    var more = ParseArgValues(tokens, value);
    if (more.Values.Length > 1) {
      return more.Ok();
    }

    var values = new List<ArgumentAst> { value };
    while (_argument.Parse(tokens).Required(values.Add)) { }

    if (tokens.Take(")")) {
      var argument = values.Count > 1 ? new(at, values.ToArray()) : value;
      return argument.Ok();
    }

    return tokens.Error("Argument", "a value", more);
  }
}

public interface IParserArgument : IParser<ArgumentAst> { }
