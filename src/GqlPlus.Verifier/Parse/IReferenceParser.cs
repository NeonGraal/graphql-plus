using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal interface IReferenceParser<R> : IReferenceFactories<R>
  where R : AstReference<R>
{
  bool TypeEnumLabel(R reference);
}
