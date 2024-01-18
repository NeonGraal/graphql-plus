using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

internal class ParseCollections : IParserCollections
{
  public IResultArray<ModifierAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var list = new List<ModifierAst>();

    var at = tokens.At;
    while (tokens.Take('[')) {
      var modifier = ModifierAst.List(at);
      if (tokens.Identifier(out var key)) {
        modifier = new(at, key, tokens.Take('?'));
      } else {
        if (tokens.TakeAny(out var charType, '^', '0', '*')) {
          modifier = new(at, charType.ToString(), tokens.Take('?'));
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

public interface IParserCollections : Parser<ModifierAst>.IA { }
