using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class OutputFactories
  : IObjectFactories<OutputDeclAst, OutputFieldAst, OutputBaseAst>
{
  public OutputFieldAst ObjField(TokenAt at, string name, OutputBaseAst typeBase, string description)
    => new(at, name, description, typeBase);

  public OutputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public OutputBaseAst ObjBase(TokenAt at, string name, string description)
    => new(at, name, description);
}
