using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal interface IFieldFactories<F, R>
  : IReferenceFactories<R>
  where F : AstField<R>
  where R : AstReference<R>
{
  F Field(ParseAt at, string name, string description, R typeReference);
}
