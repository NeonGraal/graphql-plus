using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

internal class ParseModifiers : IParserArray<ModifierAst>
{
  public IResultArray<ModifierAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var list = new List<ModifierAst>();

    var at = tokens.At;
    while (tokens.Take('[')) {
      var modifier = ModifierAst.List(at);
      if (tokens.Identifier(out var key)) {
        modifier = new(at, key, tokens.Take('?'));
      } else {
        if (tokens.TakeAny(out var charType, '~', '0', '*')) {
          modifier = new(at, charType.ToString(), tokens.Take('?'));
        }
      }

      if (tokens.Take(']')) {
        list.Add(modifier);
      } else {
        return tokens.PartialArray("Modifier", "']' at end of list or dictionary modifier.", () => list);
      }

      at = tokens.At;
    }

    if (tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }
}
