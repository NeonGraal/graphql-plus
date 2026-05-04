using GqlPlus;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArg(
  IParserRepository parsers
) : IParserArg
{
  private readonly Parser<IAstFieldKey>.L _fieldKey = parsers.ParserFor<IAstFieldKey>();
  private readonly Parser<IValueParser<IAstArg>, IAstArg>.L _argument = parsers.ParserFor<IValueParser<IAstArg>, IAstArg>();

  public IResult<IAstArg> Parse(ITokenizer tokens, string label)

  {
    if (!tokens.Take('(')) {
      return default(IAstArg).Empty();
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      TokenAt at = tokens.At;
      IAstArg? value = new ArgAst(at);

      IResult<IAstFieldKey> fieldKey = _fieldKey.Parse(tokens, label);
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

      IResult<IAstArg> argValue = _argument.I.Parse(tokens, label);

      return argValue.MapOk(value => ParseArgEnd(tokens, at, value), () => argValue);
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private IAstArg ParseArgValues(ITokenizer tokens, IAstArg initial)
  {
    ITokenAt at = initial.At;
    List<IAstArg> values = [initial];
    while (tokens.Take(',')) {
      _argument.I.Parse(tokens, "Arg").Required(values.Add);
    }

    return values.Count > 1
      ? new ArgAst(at, values)
      : initial;
  }

  private IResult<IAstArg> ParseArgMid(ITokenizer tokens, TokenAt at, FieldsAst<IAstArg> fields)
  {
    if (tokens.Take(',')) {
      return _argument.I
        .ParseFieldValues(tokens, "Arg", ')', fields)
        .Select(result => new ArgAst(at, result) as IAstArg);
    }

    while (!tokens.Take(')')) {
      IResult<KeyValue<IAstArg>> field = _argument.I.KeyValueParser.Parse(tokens, "Arg");

      if (!field.Required(value => fields.Add(value.Key, ParseArgValues(tokens, value.Value)))) {
        return field.IsEmpty()
          ? Result().Error(tokens.Error("Arg", "fields"))
          : field.AsResult(Result());
      }
    }

    return Result().Ok();

    IAstArg Result() => new ArgAst(at, fields);
  }

  private IResult<IAstArg> ParseArgEnd(ITokenizer tokens, TokenAt at, IAstArg value)
  {
    IAstArg more = ParseArgValues(tokens, value);
    if (more.Values.Count() > 1) {
      return more.Ok();
    }

    List<IAstArg> values = [value];
    while (_argument.I.Parse(tokens, "Arg").Required(values.Add)) { }

    if (tokens.Take(')')) {
      IAstArg argument = values.Count > 1 ? new ArgAst(at, values) : value;
      return argument.Ok();
    }

    return tokens.Error("Arg", "a value", more);
  }

  internal static ParseArg Factory(IParserRepository p) => new(p);
}

public interface IParserArg
  : Parser<IAstArg>.I
{ }
