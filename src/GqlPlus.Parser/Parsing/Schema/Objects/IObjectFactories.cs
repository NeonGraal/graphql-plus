using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst>
  : IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst>
  , IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst>
  where TObject : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  TObject Object(TokenAt at, string name, string description = "");
}
