using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFactories<TObjField, TObjFieldAst>
  : IObjectFieldFactories<TObjFieldAst>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
{
  AstObject<TObjField> Object(TokenAt at, string name, string description = "");
}
