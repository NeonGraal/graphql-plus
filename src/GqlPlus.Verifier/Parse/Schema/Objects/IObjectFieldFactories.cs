using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal interface IObjectFieldFactories<F, R>
  : IReferenceFactories<R>
  where F : AstObjectField<R> where R : AstReference<R>
{
  F Field(TokenAt at, string name, R typeReference, string description = "");
}
