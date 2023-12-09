using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

internal class ParseFieldKey : Parser<FieldKeyAst>.I
{
  private readonly Dictionary<string, string> _enumValueTypes = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  public IResult<FieldKeyAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    if (tokens.Number(out var number)) {
      return new FieldKeyAst(at, number).Ok();
    }

    if (tokens.String(out var contents)) {
      return new FieldKeyAst(at, contents).Ok();
    }

    if (tokens.Identifier(out var enumType)) {
      if (tokens.Take('.')) {
        return tokens.Identifier(out var enumValue)
          ? new FieldKeyAst(at, enumType, enumValue).Ok()
          : tokens.Error<FieldKeyAst>(label, "enum value after '.'");
      }

      var type = _enumValueTypes.GetValueOrDefault(enumType, "");
      return new FieldKeyAst(at, type, enumType).Ok();
    }

    return 0.Empty<FieldKeyAst>();
  }
}
