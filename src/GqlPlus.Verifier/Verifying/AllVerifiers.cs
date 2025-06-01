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
      .AddVerifyUsageAliased<IGqlpSchemaCategory, VerifyCategoryAliased, VerifyCategoryOutput>()
      .AddVerifyUsageAliased<IGqlpSchemaDirective, VerifyDirectiveAliased, VerifyDirectiveInput>()
      .AddVerifyAliased<IGqlpSchemaOption, VerifyOptionAliased>()
      // Schema Types
      .AddVerify<IGqlpType[], VerifyAllTypes>()

      .AddVerifyAliased<IGqlpType, VerifyAllTypesAliased>()
      // Simple Types
      .AddVerifyUsageAliased<IGqlpDomain, VerifyDomainsAliased, VerifyDomainTypes>()
      .AddVerifyDomainContext<AstDomainVerifier<IGqlpDomainRange>>()
      .AddVerifyDomainContext<AstDomainVerifier<IGqlpDomainRegex>>()
      .AddVerifyDomainContext<AstDomainVerifier<IGqlpDomainTrueFalse>>()
      .AddVerifyDomainContext<VerifyDomainEnum>()
      .AddVerifyUsageAliased<IGqlpEnum, VerifyEnumsAliased, VerifyEnumTypes>()
      .AddVerifyUsageAliased<IGqlpUnion, VerifyUnionsAliased, VerifyUnionTypes>()
      // Object Types
      .AddSingleton<ObjectVerifierParams<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate, IGqlpDualArg>>()
      .AddVerifyUsageAliased<IGqlpDualObject, VerifyDualsAliased, VerifyDualTypes>()
      .AddSingleton<ObjectVerifierParams<IGqlpInputObject, IGqlpInputField, IGqlpInputAlternate, IGqlpInputArg>>()
      .AddVerifyUsageAliased<IGqlpInputObject, VerifyInputsAliased, VerifyInputTypes>()
      .AddSingleton<ObjectVerifierParams<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputArg>>()
      .AddVerifyUsageAliased<IGqlpOutputObject, VerifyOutputsAliased, VerifyOutputTypes>()
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

  private static IServiceCollection AddVerifyAliased<TAliased, TAliasedService>(this IServiceCollection services)
    where TAliasedService : class, IVerifyAliased<TAliased>
    where TAliased : IGqlpAliased
    => services
      .AddSingleton<IVerifyAliased<TAliased>, TAliasedService>()
      .TryAddVerify<TAliased, NullVerifierError<TAliased>>();

  private static IServiceCollection AddVerifyUsageAliased<TUsage, TAliasedService, TUsageService>(this IServiceCollection services)
    where TAliasedService : class, IVerifyAliased<TUsage>
    where TUsageService : class, IVerifyUsage<TUsage>
    where TUsage : IGqlpAliased
    => services
      .AddSingleton<IVerifyAliased<TUsage>, TAliasedService>()
      .AddSingleton<IVerifyUsage<TUsage>, TUsageService>()
      .TryAddVerify<TUsage, NullVerifierError<TUsage>>();

  private static IServiceCollection AddVerifyDomainContext<TService>(this IServiceCollection services)
    where TService : class, IVerifyDomain
    => services.AddSingleton<IVerifyDomain, TService>();
}
