using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst>
  : IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst>
  , IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst>
  where TObject : AstObject<TObjField, TObjAlt, TObjBase>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  TObject Object(TokenAt at, string name, string description = "");
}
