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
        if (ParseConstraint(tokens, out string? constraint)) {
          list.Add(new TypeParamAst(at, name, description, constraint));
        } else {
          list.Add(new TypeParamAst(at, name, description, ""));
          return list.PartialArray(tokens.Error(label, "constraint after ':' for $" + name));
        }
      } else {
        return list.PartialArray(tokens.Error(label, "type parameter"));
      }
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one type parameter after '<'", list) : list.OkArray();
  }

  private static bool ParseConstraint(ITokenizer tokens, [NotNullWhen(true)] out string? constraint)
  {
    if (tokens.Take(':')) {
      if (tokens.Identifier(out constraint)) {
        return true;
      } else if (tokens.TakeZero()) {
        constraint = "0";
        return true;
      } else if (tokens.TakeAny(out char charType, '^', '_', '*')) {
        constraint = charType.ToString();
        return true;
      }
    }

    constraint = "";
    return false;
  }
}
