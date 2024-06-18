using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualAlternate(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpDualBase>.D parseBase
) : ObjectAlternatesParser<IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase>(collections, parseBase)
{
  protected override DualAlternateAst ObjAlternate(TokenAt at, IGqlpDualBase objBase)
    => new(at, objBase);
}
