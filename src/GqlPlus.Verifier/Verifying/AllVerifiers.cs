using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Verification;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Globals;
using GqlPlus.Verifying.Schema.Objects;
using GqlPlus.Verifying.Schema.Simple;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Verifying;

public static class AllVerifiers
{
  public static IServiceCollection AddVerifiers(this IServiceCollection services)
    => services
      // Operation
      .AddVerify<IGqlpOperation, VerifyOperation>()
      .AddVerify<IGqlpVariable, VerifyVariable>()
      .AddVerifyUsageNamed<IGqlpArgument, IGqlpVariable, VerifyVariableUsage>()
      .AddVerifyUsageNamed<IGqlpSpread, IGqlpFragment, VerifyFragmentUsage>()
      // Schema
      .AddVerify<IGqlpSchema, VerifySchema>()
      .AddVerifyAliased<IGqlpSchemaCategory, VerifyCategoryAliased>()
      .AddVerifyUsageAliased<IGqlpSchemaCategory, VerifyCategoryOutput>()
      .AddVerifyAliased<IGqlpSchemaDirective, VerifyDirectiveAliased>()
      .AddVerifyUsageAliased<IGqlpSchemaDirective, VerifyDirectiveInput>()
      .AddVerifyAliased<IGqlpSchemaOption, VerifyOptionAliased>()
      // Schema Types
      .AddVerify<IGqlpType[], VerifyAllTypes>()
      .AddVerifyAliased<IGqlpType, VerifyAllTypesAliased>()
      // Simple Types
      .AddVerifyAliased<IGqlpDomain, VerifyDomainsAliased>()
      .AddVerifyUsageAliased<IGqlpDomain, VerifyDomainTypes>()
      .AddVerifyDomainContext<AstDomainVerifier<IGqlpDomainRange>>()
      .AddVerifyDomainContext<AstDomainVerifier<IGqlpDomainRegex>>()
      .AddVerifyDomainContext<AstDomainVerifier<IGqlpDomainTrueFalse>>()
      .AddVerifyDomainContext<VerifyDomainEnum>()
      .AddVerifyAliased<IGqlpEnum, VerifyEnumsAliased>()
      .AddVerifyUsageAliased<IGqlpEnum, VerifyEnumTypes>()
      .AddVerifyAliased<IGqlpUnion, VerifyUnionsAliased>()
      .AddVerifyUsageAliased<IGqlpUnion, VerifyUnionTypes>()
      // Object Types
      .AddVerifyAliased<DualDeclAst, VerifyDualsAliased>()
      .AddVerifyUsageAliased<DualDeclAst, VerifyDualTypes>()
      .AddVerifyAliased<InputDeclAst, VerifyInputsAliased>()
      .AddVerifyUsageAliased<InputDeclAst, VerifyInputTypes>()
      .AddVerifyAliased<OutputDeclAst, VerifyOutputsAliased>()
      .AddVerifyUsageAliased<OutputDeclAst, VerifyOutputTypes>()
    ;

  private static IServiceCollection AddVerify<TValue, TService>(this IServiceCollection services)
    where TService : class, IVerify<TValue>
    => services.AddSingleton<IVerify<TValue>, TService>();

  private static IServiceCollection TryAddVerify<TValue, TService>(this IServiceCollection services)
    where TService : class, IVerify<TValue>
  {
    services.TryAddSingleton<IVerify<TValue>, TService>();
    return services;
  }

  private static IServiceCollection AddVerifyUsageNamed<TUsage, TNamed, TService>(this IServiceCollection services)
    where TService : class, IVerifyNamed<TUsage, TNamed>
    where TUsage : IGqlpError
    where TNamed : IGqlpNamed
  => services
      .AddSingleton<IVerifyNamed<TUsage, TNamed>, TService>()
      .TryAddVerify<TUsage, NullVerifierError<TUsage>>()
      .TryAddVerify<TNamed, NullVerifierError<TNamed>>();

  private static IServiceCollection AddVerifyAliased<TAliased, TService>(this IServiceCollection services)
    where TService : class, IVerifyAliased<TAliased>
    where TAliased : IGqlpAliased
    => services
      .AddSingleton<IVerifyAliased<TAliased>, TService>()
      .TryAddVerify<TAliased, NullVerifierError<TAliased>>();

  private static IServiceCollection AddVerifyUsageAliased<TUsage, TService>(this IServiceCollection services)
    where TService : class, IVerifyUsage<TUsage>
    where TUsage : IGqlpError
    => services
      .AddSingleton<IVerifyUsage<TUsage>, TService>()
      .TryAddVerify<TUsage, NullVerifierError<TUsage>>();

  private static IServiceCollection AddVerifyDomainContext<TService>(this IServiceCollection services)
    where TService : class, IVerifyDomain
    => services.AddSingleton<IVerifyDomain, TService>();
}
