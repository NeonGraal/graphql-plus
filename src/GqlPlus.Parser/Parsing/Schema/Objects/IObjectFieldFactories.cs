using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectFieldFactories<TObjField, TObjBase, TObjBaseAst>
  : IObjectBaseFactories<TObjBaseAst>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>, TObjBase
{
  TObjField ObjField(TokenAt at, string name, TObjBase typeBase, string description = "");
}
