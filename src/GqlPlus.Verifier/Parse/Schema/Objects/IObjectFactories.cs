using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal interface IObjectFactories<TObject, TObjField, TObjBase>
  : IObjectFieldFactories<TObjField, TObjBase>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  TObject Object(TokenAt at, string name, string description = "");
}
