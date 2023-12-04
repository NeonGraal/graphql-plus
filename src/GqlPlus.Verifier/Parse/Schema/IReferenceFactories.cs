using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public interface IReferenceFactories<R>
  where R : AstReference<R>
{
  R Reference(TokenAt at, string name);
}
