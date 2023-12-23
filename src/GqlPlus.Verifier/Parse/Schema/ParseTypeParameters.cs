using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseTypeParameters : Parser<TypeParameterAst>.IA
{
  public IResultArray<TypeParameterAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var list = new List<TypeParameterAst>();

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    while (!tokens.Take('>')) {
      tokens.String(out var description);
      if (tokens.Prefix('$', out var name, out var at) && name is not null) {
        list.Add(new(at, name, description));
      } else {
        return tokens.PartialArray(label, "type parameter", () => list);
      }
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one type parameter after '<'", list) : list.OkArray();
  }
}
