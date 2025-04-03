using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
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
      .AddVerifyUsageIdentified<IGqlpArg, IGqlpVariable, VerifyVariableUsage>()
      .AddVerifyUsageIdentified<IGqlpSpread, IGqlpFragment, VerifyFragmentUsage>()
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
      .AddVerifyAliased<IGqlpDualObject, VerifyDualsAliased>()
      .AddVerifyUsageAliased<IGqlpDualObject, VerifyDualTypes>()
      .AddVerifyAliased<IGqlpInputObject, VerifyInputsAliased>()
      .AddVerifyUsageAliased<IGqlpInputObject, VerifyInputTypes>()
      .AddVerifyAliased<IGqlpOutputObject, VerifyOutputsAliased>()
      .AddVerifyUsageAliased<IGqlpOutputObject, VerifyOutputTypes>()
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

  private static IServiceCollection AddVerifyUsageIdentified<TUsage, TIdentified, TService>(this IServiceCollection services)
    where TService : class, IVerifyIdentified<TUsage, TIdentified>
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
  => services
      .AddSingleton<IVerifyIdentified<TUsage, TIdentified>, TService>()
      .TryAddVerify<TUsage, NullVerifierError<TUsage>>()
      .TryAddVerify<TIdentified, NullVerifierError<TIdentified>>();

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
      .AddSingleton<IVerifyUsage<TUsage>, TService>();

  private static IServiceCollection AddVerifyDomainContext<TService>(this IServiceCollection services)
    where TService : class, IVerifyDomain
    => services.AddSingleton<IVerifyDomain, TService>();
}
