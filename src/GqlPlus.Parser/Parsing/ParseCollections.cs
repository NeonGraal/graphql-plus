using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseCollections
  : IParserCollections
{
  public IResultArray<IGqlpModifier> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<IGqlpModifier> list = [];

    TokenAt at = tokens.At;
    while (tokens.Take('[')) {
      ModifierAst modifier = ModifierAst.List(at);
      if (tokens.Take('$')) {
        if (tokens.Identifier(out string? param)) {
          modifier = ModifierAst.Param(at, param, tokens.Take('?'));
        } else {
          return tokens.PartialArray(label, "Identifier after '$'.", () => list);
        }
      } else if (tokens.Identifier(out string? key)) {
        modifier = ModifierAst.Dict(at, key, tokens.Take('?'));
      } else {
        if (tokens.TakeAny(out char charType, '^', '0', '*')) {
          modifier = ModifierAst.Dict(at, charType.ToString(), tokens.Take('?'));
        }
      }

      if (tokens.Take(']')) {
        list.Add(modifier);
      } else {
        return tokens.PartialArray(label, "']' at end of list or dictionary modifier.", () => list);
      }

      at = tokens.At;
    }

    return list.OkArray();
  }
}

public interface IParserCollections
  : Parser<IGqlpModifier>.IA
{ }
