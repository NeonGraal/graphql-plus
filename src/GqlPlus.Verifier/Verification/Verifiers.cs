using GqlPlus.Verifier.Ast.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Verification;

public static class Verifiers
{
  public static IServiceCollection AddVerifiers(this IServiceCollection services)
    => services
      .AddSingleton<IVerify<OperationAst>, VerifyOperation>()
      .AddSingleton<IVerify<ArgumentAst[]>, VerifyVariableUsage>()
      .AddSingleton<IVerify<SpreadAst[]>, VerifyFragmentUsage>()
    ;
}
