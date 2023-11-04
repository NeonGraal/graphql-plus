using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal interface IFieldParser<F, R>
  : IFieldFactories<F, R>, IReferenceParser<R>
  where F : AstField<R> where R : AstReference<R>
{
  IResult<ParameterAst> FieldParameter();
  void ApplyParameter(F result, ParameterAst? parameter);
  IResult<F> FieldDefault(F field);
  IResult<F> FieldEnumLabel(F field);
}
