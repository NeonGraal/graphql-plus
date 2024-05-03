using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse;

internal class ParseModifiers(
    ParserArray<IParserCollections, ModifierAst>.DA collections
) : Parser<ModifierAst>.IA
{
  private readonly ParserArray<IParserCollections, ModifierAst>.LA _collections = collections;

  public IResultArray<ModifierAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var list = new List<ModifierAst>();
    var collections = _collections.I.Parse(tokens, label);

    if (!collections.Optional(list.AddRange)) {
      return collections.AsResultArray<ModifierAst>();
    }

    var at = tokens.At;
    if (tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }
}
