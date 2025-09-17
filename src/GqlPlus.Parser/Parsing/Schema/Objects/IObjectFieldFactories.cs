using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst, TObjArgAst>
  : IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArgAst>
  where TObjFieldAst : AstObjField<TObjBase>, IGqlpObjField
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase, TObjBase
  where TObjArgAst : AstObjArg
{
  TObjFieldAst ObjField(TokenAt at, string name, TObjBase typeBase, string description = "");
}
