using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal interface IReferenceFactories<R>
  where R : AstReference<R>
{
  string Label { get; }
  R Reference(ParseAt at, string name);
  bool ParseEnumLabel(R reference);
}
