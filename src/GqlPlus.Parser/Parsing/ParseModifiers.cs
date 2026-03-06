using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseModifiers(
    IParserRepository parsers
) : Parser<IGqlpModifier>.IA
{
  private readonly ParserArray<IParserCollections, IGqlpModifier>.LA _collections = parsers.GetArrayInterface<IParserCollections, IGqlpModifier>();

  public IResultArray<IGqlpModifier> Parse(ITokenizer tokens, string label)

  {
    List<IGqlpModifier> list = [];
    IResultArray<IGqlpModifier> collections = _collections.I.Parse(tokens, label);

    if (!collections.Optional(list.AddRange)) {
      return collections.AsResultArray<IGqlpModifier>();
    }

    TokenAt at = tokens.At;
    if (tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }
}
