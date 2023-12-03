using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal interface IFieldFactories<F, R>
  : IReferenceFactories<R>
  where F : AstField<R> where R : AstReference<R>
{
  F Field(TokenAt at, string name, string description, R typeReference);
}
