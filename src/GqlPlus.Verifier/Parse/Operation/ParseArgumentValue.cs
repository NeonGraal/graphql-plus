using System.Reflection.Metadata;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseArgumentValue : ValueParser<ArgumentAst>
{
  private readonly Parser<ConstantAst>.L _constant;

  public ParseArgumentValue(
    Parser<FieldKeyAst>.D fieldKey,
    Parser<AstKeyValue<ArgumentAst>>.D keyValueParser,
    Parser<ArgumentAst>.DA listParser,
    Parser<AstObject<ArgumentAst>>.D objectParser,
    Parser<ConstantAst>.D constant
  ) : base(fieldKey, keyValueParser, listParser, objectParser)
    => _constant = constant;

  protected override string Label => "Argument";

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

      var list = ParseList(tokens);
      if (!list.IsEmpty()) {
        return list.Select(value => new ArgumentAst(at, value));
      }

      var fields = ParseObject(tokens);
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
