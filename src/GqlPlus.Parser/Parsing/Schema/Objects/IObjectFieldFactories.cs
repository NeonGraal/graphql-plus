using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFieldFactories<TObjFieldAst>
  where TObjFieldAst : AstObjField, IAstObjField
{
  TObjFieldAst ObjField(TokenAt at, string name, IAstObjBase type, string description = "");
}
