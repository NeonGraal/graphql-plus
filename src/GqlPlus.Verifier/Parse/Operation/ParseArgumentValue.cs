using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseArgumentValue(
  Parser<FieldKeyAst>.D fieldKey,
  Parser<KeyValue<ArgumentAst>>.D keyValueParser,
  Parser<ArgumentAst>.DA listParser,
  Parser<AstFields<ArgumentAst>>.D objectParser,
  Parser<ConstantAst>.D constant
) : ValueParser<ArgumentAst>(fieldKey, keyValueParser, listParser, objectParser)
{
  private readonly Parser<ConstantAst>.L _constant = constant;

  public override IResult<ArgumentAst> Parse<TContext>(TContext tokens, string label)
  {
    _ = tokens.At;
    if (!tokens.Prefix('$', out var variable, out TokenAt? at)) {
      return tokens.Error<ArgumentAst>(label, "identifier after '$'");
    }

    if (variable is not null) {
      var argument = new ArgumentAst(at, variable);

      if (tokens is OperationContext context) {
        context.Variables.Add(argument);
      }

      return argument.Ok();
    }

    var oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;
      at = tokens.At;

      var list = ListParser.Parse(tokens, label);
      if (!list.IsEmpty()) {
        return list.Select(value => new ArgumentAst(at, value));
      }

      var fields = ObjectParser.Parse(tokens, label);
      if (!fields.IsEmpty()) {
        return fields.Select(value => new ArgumentAst(at, value));
      }
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }

    return _constant.Parse(tokens, "Constant").MapOk(
      constant => new ArgumentAst(constant).Ok(),
      () => 0.Empty<ArgumentAst>());
  }
}
