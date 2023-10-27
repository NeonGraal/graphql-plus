using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal interface IObjectParser<O, F, R>
  : IObjectFactories<O, F, R>, IFieldParser<F, R>
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{ }
