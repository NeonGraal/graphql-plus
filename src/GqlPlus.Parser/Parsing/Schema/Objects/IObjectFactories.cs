using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst, TObjArgAst>
  : IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst, TObjArgAst>
  , IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst, TObjArgAst>
  where TObject : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate, TObjAlt
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase, TObjBase
  where TObjArgAst : AstObjArg
{
  TObject Object(TokenAt at, string name, string description = "");
}
