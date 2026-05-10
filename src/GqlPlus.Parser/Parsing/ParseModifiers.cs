using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseModifiers(
    IParserRepository parsers
) : IParserArray<IAstModifier>
{
  private readonly ParserArray<IParserCollections, IAstModifier> _collections = parsers.ArrayFor<IParserCollections, IAstModifier>();

  public IResultArray<IAstModifier> Parse([NotNull] ITokenizer tokens, string label)

  {
    List<IAstModifier> list = [];
    IResultArray<IAstModifier> collections = _collections.Parse(tokens, label);

    if (!collections.Optional(list.AddRange)) {
      return collections.AsResultArray<IAstModifier>();
    }

    TokenAt at = tokens.At;
    if (tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }

  internal static ParseModifiers Factory(IParserRepository p) => new(p);
}
