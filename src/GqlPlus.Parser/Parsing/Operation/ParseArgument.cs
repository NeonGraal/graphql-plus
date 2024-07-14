﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArg(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<IValueParser<IGqlpArg>, IGqlpArg>.D argument
) : IParserArg
{
  private readonly Parser<IGqlpFieldKey>.L _fieldKey = fieldKey;
  private readonly Parser<IValueParser<IGqlpArg>, IGqlpArg>.L _argument = argument;

  public IResult<IGqlpArg> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (!tokens.Take('(')) {
      return 0.Empty<IGqlpArg>();
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      TokenAt at = tokens.At;
      IGqlpArg? value = new ArgAst(at);

      IResult<IGqlpFieldKey> fieldKey = _fieldKey.Parse(tokens, label);
      if (fieldKey.IsOk()) {
        return fieldKey.Map<IGqlpArg>(key =>
          tokens.Take(':')
          ? _argument.I
            .Parse(tokens, "Arg")
            .MapOk(
              item => ParseArgMid(tokens, at, new() { [(FieldKeyAst)key] = item }),
              () => tokens.Error(label, "a value after field key separator", value))
          : ParseArgEnd(tokens, at, new(key)));
      }

      IResult<IGqlpArg> argValue = _argument.I.Parse(tokens, label);

      return argValue.MapOk(value => ParseArgEnd(tokens, at, (ArgAst)value), () => argValue);
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private ArgAst ParseArgValues(Tokenizer tokens, ArgAst initial)
  {
    TokenAt at = initial.At;
    List<IGqlpArg> values = [initial];
    while (tokens.Take(',')) {
      _argument.I.Parse(tokens, "Arg").Required(values.Add);
    }

    return values.Count > 1
      ? new(at, values.ArrayOf<ArgAst>())
      : initial;
  }

  private IResult<IGqlpArg> ParseArgMid(Tokenizer tokens, TokenAt at, AstFields<IGqlpArg> fields)
  {
    if (tokens.Take(',')) {
      return _argument.I
        .ParseFieldValues(tokens, "Arg", ')', fields)
        .Select(result => new ArgAst(at, result) as IGqlpArg);
    }

    while (!tokens.Take(')')) {
      IResult<KeyValue<IGqlpArg>> field = _argument.I.KeyValueParser.Parse(tokens, "Arg");

      if (!field.Required(value => fields.Add((FieldKeyAst)value.Key, ParseArgValues(tokens, (ArgAst)value.Value)))) {
        return field.AsResult<IGqlpArg>();
      }
    }

    return new ArgAst(at, fields).Ok<IGqlpArg>();
  }

  private IResult<IGqlpArg> ParseArgEnd(Tokenizer tokens, TokenAt at, ArgAst value)
  {
    IGqlpArg more = ParseArgValues(tokens, value);
    if (more.Values.Count() > 1) {
      return more.Ok();
    }

    List<IGqlpArg> values = [value];
    while (_argument.I.Parse(tokens, "Arg").Required(values.Add)) { }

    if (tokens.Take(")")) {
      IGqlpArg argument = values.Count > 1 ? new(at, values.ArrayOf<ArgAst>()) : value;
      return argument.Ok();
    }

    return tokens.Error("Arg", "a value", more);
  }
}

public interface IParserArg
  : Parser<IGqlpArg>.I
{ }
