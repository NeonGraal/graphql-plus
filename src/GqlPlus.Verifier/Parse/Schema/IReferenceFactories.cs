using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public interface IReferenceFactories<TRef>
  where TRef : AstReference<TRef>
{
  TRef Reference(TokenAt at, string name, string description = "");
}
