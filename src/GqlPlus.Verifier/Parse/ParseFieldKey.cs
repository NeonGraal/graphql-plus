using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

internal class ParseFieldKey : Parser<FieldKeyAst>.I
{
  private readonly Dictionary<string, string> _labelTypes = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  public IResult<FieldKeyAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    if (tokens.Number(out var number)) {
      return new FieldKeyAst(at, number).Ok();
    }

    if (tokens.String(out var contents)) {
      return new FieldKeyAst(at, contents).Ok();
    }

    if (tokens.Identifier(out var identifier)) {
      if (tokens.Take('.')) {
        return tokens.Identifier(out var value)
          ? new FieldKeyAst(at, identifier, value).Ok()
          : tokens.Error<FieldKeyAst>("FieldKey", "enum value after '.'");
      }

      var type = _labelTypes.GetValueOrDefault(identifier, "");
      return new FieldKeyAst(at, type, identifier).Ok();
    }

    return 0.Empty<FieldKeyAst>();
  }
}
