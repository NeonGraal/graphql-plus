using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Verification;

public static class Verifiers
{
  public static IServiceCollection AddVerifiers(this IServiceCollection services)
    => services
      // Operation
      .AddSingleton<IVerify<OperationAst>, VerifyOperation>()
      .AddVerifyUsageNamed<ArgumentAst, VariableAst, VerifyVariableUsage>()
      .AddVerifyUsageNamed<SpreadAst, FragmentAst, VerifyFragmentUsage>()
      .AddSingleton<IVerify<VariableAst>, VerifyVariable>()
      // Schema
      .AddSingleton<IVerify<SchemaAst>, VerifySchema>()
      .AddVerifyAliased<CategoryAst, VerifyCategories>()
      .AddVerifyUsageAliased<CategoryAst, OutputAst, VerifyCategoryOutput>()
      .AddVerifyAliased<EnumAst, VerifyEnums>()
      .AddVerifyUsageAliased<EnumAst, AstType, VerifyEnumTypes>()
      .AddVerifyAliased<InputAst, VerifyInputs>()
      .AddVerifyUsageAliased<InputAst, AstType, VerifyInputTypes>()
      .AddVerifyAliased<OutputAst, VerifyOutputs>()
      .AddVerifyUsageAliased<OutputAst, AstType, VerifyOutputTypes>()
      .AddVerifyAliased<ScalarAst, VerifyScalars>()
      .AddVerifyUsageAliased<ScalarAst, AstType, VerifyScalarTypes>()
    ;

  public static IServiceCollection AddVerifyUsageNamed<U, D, S>(this IServiceCollection services)
    where S : class, IVerifyUsageNamed<U, D>
    where U : AstBase where D : AstNamed
    => services
      .AddSingleton<IVerifyUsageNamed<U, D>, S>()
      .AddSingleton<IVerify<U>, NullVerifier<U>>()
      .AddSingleton<IVerify<D>, NullVerifier<D>>()
    ;

  public static IServiceCollection AddVerifyAliased<A, S>(this IServiceCollection services)
    where S : class, IVerifyAliased<A>
    where A : AstAliased
    => services
      .AddSingleton<IVerifyAliased<A>, S>()
      .AddSingleton<IVerify<A>, NullVerifier<A>>()
    ;

  public static IServiceCollection AddVerifyUsageAliased<U, A, S>(this IServiceCollection services)
    where S : class, IVerifyUsageAliased<U, A>
    where U : AstBase where A : AstAliased
    => services
      .AddSingleton<IVerifyUsageAliased<U, A>, S>()
      .AddSingleton<IVerify<U>, NullVerifier<U>>()
      .AddSingleton<IVerify<A>, NullVerifier<A>>()
    ;
}
