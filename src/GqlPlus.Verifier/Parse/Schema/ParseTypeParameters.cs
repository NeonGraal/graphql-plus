using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseTypeParameters : IParserArray<TypeParameterAst>
{
  public IResultArray<TypeParameterAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<TypeParameterAst>();

    if (tokens.Take('<')) {
      while (!tokens.Take('>')) {
        tokens.String(out var description);
        if (tokens.Prefix('$', out var name, out var at) && name is not null) {
          result.Add(new(at, name, description));
        } else {
          return tokens.PartialArray(label, "type parameter", () => result);
        }
      }

      if (result.Count == 0) {
        return tokens.ErrorArray(label, "at least one type parameter after '<'", result);
      }
    }

    return result.OkArray();
  }
}
