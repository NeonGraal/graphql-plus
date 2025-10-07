using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFieldFactories<TObjFieldAst>
  where TObjFieldAst : AstObjField, IGqlpObjField
{
  TObjFieldAst ObjField(TokenAt at, string name, IGqlpObjBase type, string description = "");
}
