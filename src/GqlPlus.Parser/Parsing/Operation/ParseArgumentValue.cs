using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArgumentValue(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<KeyValue<IGqlpArgument>>.D keyValueParser,
  Parser<IGqlpArgument>.DA listParser,
  Parser<IGqlpFields<IGqlpArgument>>.D objectParser,
  Parser<IGqlpConstant>.D constant
) : ValueParser<IGqlpArgument>(fieldKey, keyValueParser, listParser, objectParser)
{
  private readonly Parser<IGqlpConstant>.L _constant = constant;

  public override IResult<IGqlpArgument> Parse<TContext>(TContext tokens, string label)
  {
    _ = tokens.At;
    if (!tokens.Prefix('$', out string? variable, out TokenAt? at)) {
      return tokens.Error<IGqlpArgument>(label, "identifier after '$'");
    }

    if (variable is not null) {
      ArgumentAst argument = new(at, variable);

      if (tokens is OperationContext context) {
        context.Variables.Add(argument);
      }

      return argument.Ok<IGqlpArgument>();
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;
      at = tokens.At;

      IResultArray<IGqlpArgument> list = ListParser.Parse(tokens, label);
      if (!list.IsEmpty()) {
        return list.Select(value => new ArgumentAst(at, value.ArrayOf<ArgumentAst>()) as IGqlpArgument);
      }

      IResult<IGqlpFields<IGqlpArgument>> fields = ObjectParser.Parse(tokens, label);
      if (!fields.IsEmpty()) {
        return fields.Select(value => new ArgumentAst(at, value) as IGqlpArgument);
      }
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }

    return _constant.Parse(tokens, "Constant").MapOk(
      constant => new ArgumentAst((ConstantAst)constant).Ok<IGqlpArgument>(),
      () => 0.Empty<IGqlpArgument>());
  }
}
