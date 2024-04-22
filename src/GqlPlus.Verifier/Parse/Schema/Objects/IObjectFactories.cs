using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal interface IObjectFactories<O, F, R>
  : IFieldFactories<F, R>
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  O Object(TokenAt at, string name, string description = "");
}
