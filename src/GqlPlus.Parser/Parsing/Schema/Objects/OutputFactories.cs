using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class OutputFactories
  : IObjectFactories<OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>
{
  public OutputFieldAst ObjField(TokenAt at, string name, IGqlpOutputBase typeBase, string description)
    => new(at, name, description, typeBase);

  public OutputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public OutputBaseAst ObjBase(TokenAt at, string name, string description)
    => new(at, name, description);

  public OutputAlternateAst ObjAlternate(TokenAt at, IGqlpOutputBase typeBase)
    => new(at, typeBase);

  public OutputArgAst ObjArg(TokenAt at, string name, string description = "")
    => new(at, name, description);
}
