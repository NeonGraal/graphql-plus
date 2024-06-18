using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputAlternate(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpInputBase>.D parseBase
) : ObjectAlternatesParser<IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase>(collections, parseBase)
{
  protected override InputAlternateAst ObjAlternate(TokenAt at, IGqlpInputBase objBase)
    => new(at, objBase);
}
