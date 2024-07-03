using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  : IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  where TObjFieldAst : AstObjField<TObjBase>, IGqlpObjField
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  TObjFieldAst ObjField(TokenAt at, string name, TObjBase typeBase, string description = "");
}
