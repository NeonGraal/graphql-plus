using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal interface IObjectFieldFactories<TObjField, TObjBase>
  : IObjectBaseFactories<TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  TObjField ObjField(TokenAt at, string name, TObjBase typeBase, string description = "");
}
