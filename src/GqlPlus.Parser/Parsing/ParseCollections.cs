using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseCollections
  : IParserCollections
{
  public IResultArray<IGqlpModifier> Parse(ITokenizer tokens, string label)

  {
    List<IGqlpModifier> list = [];

    TokenAt at = tokens.At;
    while (tokens.Take('[')) {
      ModifierAst modifier = ModifierAst.List(at);
      if (tokens.Take('$')) {
        if (tokens.Identifier(out string? param)) {
          modifier = ModifierAst.Param(at, param, tokens.Take('?'));
        } else {
          list.Add(modifier);
          return tokens.PartialArray(label, "identitifer after '$'.", ReturnList);
        }
      } else if (tokens.Identifier(out string? key)) {
        modifier = ModifierAst.Dict(at, key, tokens.Take('?'));
      } else if (tokens.TakeZero()) {
        modifier = ModifierAst.Dict(at, "0", tokens.Take('?'));
      } else if (tokens.TakeAny(out char charType, '^', '_', '*')) {
        modifier = ModifierAst.Dict(at, charType.ToString(), tokens.Take('?'));
      }

      list.Add(modifier);
      if (!tokens.Take(']')) {
        return tokens.PartialArray(label, "']' at end of list or dictionary modifier.", ReturnList);
      }

      at = tokens.At;
    }

    return list.OkArray();

    IEnumerable<IGqlpModifier> ReturnList()
      => list;
  }
}

public interface IParserCollections
  : Parser<IGqlpModifier>.IA
{ }
