using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal interface IObjectFactories<O, F, R>
  : IFieldFactories<F, R>
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  O Object(ParseAt at, string name, string description);
}
