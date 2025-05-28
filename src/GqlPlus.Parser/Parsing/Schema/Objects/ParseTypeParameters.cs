using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseTypeParams
  : Parser<IGqlpTypeParam>.IA
{
  public IResultArray<IGqlpTypeParam> Parse(ITokenizer tokens, string label)

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
            list.Add(result with { Constraint = constraint });
          } else if (tokens.TakeZero()) {
            list.Add(result with { Constraint = "0" });
          } else if (tokens.TakeAny(out char charType, '^', '_', '*')) {
            list.Add(result with { Constraint = charType.ToString() });
          } else {
            list.Add(result);
            return tokens.ErrorArray(label, "constraint after ':' for $" + name, list);
          }
        } else {
          list.Add(result);
          return tokens.ErrorArray(label, "constraint for $" + name, list);
        }
      } else {
        return list.PartialArray(tokens.Error(label, "type parameter"));
      }
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one type parameter after '<'", list) : list.OkArray();
  }
}
