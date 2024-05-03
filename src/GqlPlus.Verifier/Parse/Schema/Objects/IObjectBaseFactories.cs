using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public interface IObjectBaseFactories<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  TObjBase ObjBase(TokenAt at, string name, string description = "");
}
