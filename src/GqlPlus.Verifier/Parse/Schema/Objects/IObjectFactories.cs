using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal interface IObjectFactories<O, F, R>
  : IObjectFieldFactories<F, R>
  where O : AstObject<F, R> where F : AstObjectField<R> where R : AstReference<R>
{
  O Object(TokenAt at, string name, string description = "");
}
