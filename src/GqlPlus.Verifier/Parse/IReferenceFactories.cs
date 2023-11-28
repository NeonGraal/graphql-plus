using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

public interface IReferenceFactories<R>
  where R : AstReference<R>
{
  string Label { get; }
  R Reference(ParseAt at, string name);
}
