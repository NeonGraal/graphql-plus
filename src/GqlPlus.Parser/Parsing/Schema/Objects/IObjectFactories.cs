using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjFieldAst>
  : IObjectFieldFactories<TObjFieldAst>
  where TObject : AstObject<TObjField>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
{
  TObject Object(TokenAt at, string name, string description = "");
}
