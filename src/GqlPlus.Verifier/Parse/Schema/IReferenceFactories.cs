using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public interface IReferenceFactories<R>
  where R : AstReference<R>
{
  R Reference(ParseAt at, string name);
}
