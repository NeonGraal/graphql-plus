using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public interface IReferenceFactories<TRef>
  where TRef : AstReference<TRef>
{
  TRef Reference(TokenAt at, string name, string description = "");
}
