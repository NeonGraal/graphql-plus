using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualAlternates(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpDualBase>.D parseBase
) : ObjectAlternatesParser<IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, IGqlpDualArg>(collections, parseBase)
{
  protected override DualAlternateAst ObjAlternate(TokenAt at, string name, string description)
    => new(at, name, description);
}
