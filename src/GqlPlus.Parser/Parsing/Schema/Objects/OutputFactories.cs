using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

[ExcludeFromCodeCoverage]

internal class OutputFactories
  : IObjectFactories<OutputDeclAst, IGqlpOutputField, OutputFieldAst>
{
  public OutputFieldAst ObjField(TokenAt at, string name, IGqlpObjBase typeBase, string description)
    => new(at, name, description, typeBase);

  public OutputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);
}
