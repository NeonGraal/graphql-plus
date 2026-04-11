using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseModifiers(
    IParserRepository parsers
) : Parser<IAstModifier>.IA
{
  private readonly ParserArray<IParserCollections, IAstModifier>.LA _collections = parsers.ArrayFor<IParserCollections, IAstModifier>();

  public IResultArray<IAstModifier> Parse(ITokenizer tokens, string label)

  {
    List<IAstModifier> list = [];
    IResultArray<IAstModifier> collections = _collections.I.Parse(tokens, label);

    if (!collections.Optional(list.AddRange)) {
      return collections.AsResultArray<IAstModifier>();
    }

    TokenAt at = tokens.At;
    if (tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }
}
