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
    List<ModifierAst> list = [];
    IResultArray<ModifierAst> collections = _collections.I.Parse(tokens, label);

    if (!collections.Optional(list.AddRange)) {
      return collections.AsResultArray<ModifierAst>();
    }

    TokenAt at = tokens.At;
    if (tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }
}
