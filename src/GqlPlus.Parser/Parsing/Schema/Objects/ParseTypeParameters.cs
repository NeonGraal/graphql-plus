using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseTypeParams
  : Parser<IGqlpTypeParam>.IA
{
  public IResultArray<IGqlpTypeParam> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<IGqlpTypeParam> list = [];

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    while (!tokens.Take('>')) {
      string description = tokens.Description();
      if (tokens.Prefix('$', out string? name, out TokenAt? at) && name is not null) {
        TypeParamAst result = new(at, name, description);

        if (tokens.Take(':')) {
          if (tokens.Identifier(out string? constraint)) {
            result = result with { Constraint = constraint };
          } else {
            return tokens.ErrorArray(label, "constraint after ':'", list);
          }
        }

        list.Add(result);
      } else {
        return tokens.PartialArray(label, "type parameter", () => list);
      }
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one type parameter after '<'", list) : list.OkArray();
  }
}
