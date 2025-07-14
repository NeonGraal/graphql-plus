using GqlPlus.Abstractions.Operation;
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

  public IResult<IGqlpArg> Parse(ITokenizer tokens, string label)

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
        return fieldKey.Map(key =>
          tokens.Take(':')
          ? _argument.I
            .Parse(tokens, "Arg")
            .MapOk(
              item => ParseArgMid(tokens, at, new(key, item)),
              () => tokens.Error(label, "a value after field key separator", value))
          : ParseArgEnd(tokens, at, new ArgAst(key)));
      }

      IResult<IGqlpArg> argValue = _argument.I.Parse(tokens, label);

      return argValue.MapOk(value => ParseArgEnd(tokens, at, value), () => argValue);
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private IGqlpArg ParseArgValues(ITokenizer tokens, IGqlpArg initial)
  {
    ITokenAt at = initial.At;
    List<IGqlpArg> values = [initial];
    while (tokens.Take(',')) {
      _argument.I.Parse(tokens, "Arg").Required(values.Add);
    }

    return values.Count > 1
      ? new ArgAst(at, values)
      : initial;
  }

  private IResult<IGqlpArg> ParseArgMid(ITokenizer tokens, TokenAt at, AstFields<IGqlpArg> fields)
  {
    if (tokens.Take(',')) {
      return _argument.I
        .ParseFieldValues(tokens, "Arg", ')', fields)
        .Select(result => new ArgAst(at, result) as IGqlpArg);
    }

    while (!tokens.Take(')')) {
      IResult<KeyValue<IGqlpArg>> field = _argument.I.KeyValueParser.Parse(tokens, "Arg");

      if (!field.Required(value => fields.Add(value.Key, ParseArgValues(tokens, value.Value)))) {
        return field.IsEmpty()
          ? Result().Error(tokens.Error("Arg", "fields"))
          : field.AsResult(Result());
      }
    }

    return Result().Ok();

    IGqlpArg Result() => new ArgAst(at, fields);
  }

  private IResult<IGqlpArg> ParseArgEnd(ITokenizer tokens, TokenAt at, IGqlpArg value)
  {
    IGqlpArg more = ParseArgValues(tokens, value);
    if (more.Values.Count() > 1) {
      return more.Ok();
    }

    List<IGqlpArg> values = [value];
    while (_argument.I.Parse(tokens, "Arg").Required(values.Add)) { }

    if (tokens.Take(')')) {
      IGqlpArg argument = values.Count > 1 ? new ArgAst(at, values) : value;
      return argument.Ok();
    }

    return tokens.Error("Arg", "a value", more);
  }
}

public interface IParserArg
  : Parser<IGqlpArg>.I
{ }
