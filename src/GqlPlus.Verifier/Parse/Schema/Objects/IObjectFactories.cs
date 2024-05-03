using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjBase>
  : IObjectFieldFactories<TObjField, TObjBase>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  TObject Object(TokenAt at, string name, string description = "");
}
