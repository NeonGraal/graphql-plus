using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

[ExcludeFromCodeCoverage]
internal sealed class DualFactories
  : IObjectFactories<DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, DualBaseAst, IGqlpDualArg, DualArgAst>
{
  public DualFieldAst ObjField(TokenAt at, string name, IGqlpDualBase typeBase, string description)
    => new(at, name, description, typeBase);

  public DualDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public DualBaseAst ObjBase(TokenAt at, string name, string description)
    => new(at, name, description);

  public DualAlternateAst ObjAlternate(TokenAt at, string name, string description)
    => new(at, name, description);

  public DualArgAst ObjArg(TokenAt at, string name, string description = "")
    => new(at, name, description);
}
