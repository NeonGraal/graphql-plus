using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputAlternates(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpOutputBase>.D parseBase
) : ObjectAlternatesParser<IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase>(collections, parseBase)
{
  protected override OutputAlternateAst ObjAlternate(TokenAt at, IGqlpOutputBase objBase)
    => new(at, objBase);
}
