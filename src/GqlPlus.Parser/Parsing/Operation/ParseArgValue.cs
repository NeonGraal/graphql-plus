using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArgValue(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<KeyValue<IGqlpArg>>.D keyValueParser,
  Parser<IGqlpArg>.DA listParser,
  Parser<IGqlpFields<IGqlpArg>>.D objectParser,
  Parser<IGqlpConstant>.D constant
) : ValueParser<IGqlpArg>(fieldKey, keyValueParser, listParser, objectParser)
{
  private readonly Parser<IGqlpConstant>.L _constant = constant;

  public override IResult<IGqlpArg> Parse(ITokenizer tokens, string label)
  {
    _ = tokens.At;
    if (!tokens.Prefix('$', out string? variable, out TokenAt? at)) {
      return tokens.Error<IGqlpArg>(label, "identifier after '$'");
    }

    if (variable is not null) {
      ArgAst argument = new(at, variable);

      if (tokens is IOperationContext context) {
        context.Variables.Add(argument);
      }

      return argument.Ok<IGqlpArg>();
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;
      at = tokens.At;

      IResultArray<IGqlpArg> list = ListParser.Parse(tokens, label);
      if (!list.IsEmpty()) {
        return list.Select(value => new ArgAst(at, value.ArrayOf<ArgAst>()) as IGqlpArg);
      }

      IResult<IGqlpFields<IGqlpArg>> fields = ObjectParser.Parse(tokens, label);
      if (!fields.IsEmpty()) {
        return fields.Select(value => new ArgAst(at, value) as IGqlpArg);
      }
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }

    return _constant.Parse(tokens, "Constant").MapOk(
      constant => new ArgAst((ConstantAst)constant).Ok<IGqlpArg>(),
      () => 0.Empty<IGqlpArg>());
  }
}
