using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  : IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  , IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  where TObject : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  TObject Object(TokenAt at, string name, string description = "");
}
