using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

internal class ParseFieldKey : IParser<FieldKeyAst>
{
  private readonly Dictionary<string, string> _labelTypes = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  public IResult<FieldKeyAst> Parse(Tokenizer tokens, string _)
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
        return tokens.Identifier(out var label)
          ? new FieldKeyAst(at, identifier, label).Ok()
          : tokens.Error<FieldKeyAst>("FieldKey", "label after '.'");
      }

      var type = _labelTypes.GetValueOrDefault(identifier, "");
      return new FieldKeyAst(at, type, identifier).Ok();
    }

    return 0.Empty<FieldKeyAst>();
  }
}
