using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst>
  : IObjectBaseFactories<TObjBase, TObjBaseAst>
  where TObjFieldAst : AstObjField<TObjBase>, IGqlpObjField<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  TObjFieldAst ObjField(TokenAt at, string name, TObjBase typeBase, string description = "");
}
