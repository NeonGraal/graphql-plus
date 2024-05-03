using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal class ParseTypeParameters
  : Parser<TypeParameterAst>.IA
{
  public IResultArray<TypeParameterAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<TypeParameterAst> list = [];

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    while (!tokens.Take('>')) {
      tokens.String(out string? description);
      if (tokens.Prefix('$', out string? name, out TokenAt? at) && name is not null) {
        list.Add(new(at, name, description));
      } else {
        return tokens.PartialArray(label, "type parameter", () => list);
      }
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one type parameter after '<'", list) : list.OkArray();
  }
}
