using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputAlternates(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpInputBase>.D parseBase
) : ObjectAlternatesParser<IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, IGqlpObjArg>(collections, parseBase)
{
  protected override InputAlternateAst ObjAlternate(TokenAt at, string name, string description)
    => new(at, name, description);
}
