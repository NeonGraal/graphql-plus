using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseArgument : IParserArgument
{
  protected readonly Parser<FieldKeyAst>.L FieldKey;
  protected readonly IValueParser<ArgumentAst> Argument;
  private readonly Parser<ArgumentAst>.L Value;

  public ParseArgument(
    Parser<FieldKeyAst>.D fieldKey,
    IValueParser<ArgumentAst> argument,
    Parser<ArgumentAst>.D value)
  {
    FieldKey = fieldKey;
    Argument = argument.ThrowIfNull();
    Value = value;
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

      var fieldKey = FieldKey.Parse(tokens, "Argument");
      if (fieldKey.IsOk()) {
        return fieldKey.Map(key =>
          tokens.Take(':')
          ? Argument.Parse(tokens).MapOk(
            item => ParseArgumentMid(tokens, at, new() { [key] = item }),
            () => tokens.Error("Argument", "a value after field key separator", value))
          : ParseArgumentEnd(tokens, at, key));
      }

      var argValue = Argument.Parse(tokens);

      return argValue.MapOk(value => ParseArgumentEnd(tokens, at, value), () => argValue);
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

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

      var fieldKey = FieldKey.Parse(tokens, label);
      if (fieldKey.IsOk()) {
        return fieldKey.Map(key =>
          tokens.Take(':')
          ? Argument.Parse(tokens).MapOk(
            item => ParseArgumentMid(tokens, at, new() { [key] = item }),
            () => tokens.Error(label, "a value after field key separator", value))
          : ParseArgumentEnd(tokens, at, key));
      }

      var argValue = Value.Parse(tokens, label);

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
      Argument.Parse(tokens).Required(values.Add);
    }

    return values.Count > 1
      ? new(at, values.ToArray())
      : initial;
  }

  private IResult<ArgumentAst> ParseArgumentMid(Tokenizer tokens, TokenAt at, AstObject<ArgumentAst> fields)
  {
    if (tokens.Take(',')) {
      return Argument.ParseFieldValues(tokens, ')', fields).Select(result => new ArgumentAst(at, result));
    }

    while (!tokens.Take(')')) {
      var field = Argument.KeyValueParser.Parse(tokens, "Argument");

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
    while (Value.Parse(tokens, "Argument").Required(values.Add)) { }

    if (tokens.Take(")")) {
      var argument = values.Count > 1 ? new(at, values.ToArray()) : value;
      return argument.Ok();
    }

    return tokens.Error("Argument", "a value", more);
  }
}

public interface IParserArgument
  : IParser<ArgumentAst>, Parser<ArgumentAst>.I
{ }
