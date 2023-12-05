using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Verification;

public static class Verifiers
{
  public static IServiceCollection AddVerifiers(this IServiceCollection services)
    => services
      .AddSingleton<IVerify<OperationAst>, VerifyOperation>()
      .AddVerifyUsage<ArgumentAst, VariableAst, VerifyVariableUsage>()
      .AddVerifyUsage<SpreadAst, FragmentAst, VerifyFragmentUsage>()
      .AddSingleton<IVerify<VariableAst>, VerifyVariable>()
    ;

  public static IServiceCollection AddVerifyUsage<U, D, S>(this IServiceCollection services)
    where S : class, IVerifyUsage<U, D>
    where U : AstBase where D : AstNamed
    => services
      .AddSingleton<IVerifyUsage<U, D>, S>()
      .AddSingleton<IVerify<U>, NullVerifier<U>>()
      .AddSingleton<IVerify<D>, NullVerifier<D>>()
    ;
}
