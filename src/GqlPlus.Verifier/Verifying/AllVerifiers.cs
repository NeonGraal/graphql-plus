using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
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
    => services.AddVerifiers(b => b
      // Operation
      .AddVerify<IGqlpOperation>(v => new VerifyOperation(v))
      .AddVerify<IGqlpVariable>(_ => new VerifyVariable())
      .AddVerifyUsageIdentified<IGqlpArg, IGqlpVariable>(v => new VerifyVariableUsage(v))
      .AddVerifyUsageIdentified<IGqlpSpread, IGqlpFragment>(v => new VerifyFragmentUsage(v))
      // Schema
      .AddVerify<IGqlpSchema>(v => new VerifySchema(v))
      .AddVerifyUsageAliased<IGqlpSchemaCategory>(
        v => new VerifyCategoryAliased(v),
        v => new VerifyCategoryOutput(v))
      .AddVerifyUsageAliased<IGqlpSchemaDirective>(
        v => new VerifyDirectiveAliased(v),
        v => new VerifyDirectiveInput(v))
      .AddVerifyAliased<IGqlpSchemaOption>(v => new VerifyOptionAliased(v))
      // Schema Types
      .AddVerify<IGqlpType[]>(v => new VerifyAllTypes(v))
      .AddVerifyAliased<IGqlpType>(v => new VerifyAllTypesAliased(v))
      // Simple Types
      .AddVerifyUsageAliased<IGqlpDomain>(
        v => new VerifyDomainsAliased(v),
        v => new VerifyDomainTypes(v))
      .AddDomain(v => new AstDomainVerifier<IGqlpDomainRange>(v))
      .AddDomain(v => new AstDomainVerifier<IGqlpDomainRegex>(v))
      .AddDomain(v => new AstDomainVerifier<IGqlpDomainTrueFalse>(v))
      .AddDomain(v => new VerifyDomainEnum(v))
      .AddVerifyUsageAliased<IGqlpEnum>(
        v => new VerifyEnumsAliased(v),
        v => new VerifyEnumTypes(v))
      .AddVerifyUsageAliased<IGqlpUnion>(
        v => new VerifyUnionsAliased(v),
        v => new VerifyUnionTypes(v))
      // Object Types
      .AddVerifyObject<IGqlpDualField>(v => new VerifyDualTypes(v))
      .AddVerifyObject<IGqlpInputField>(v => new VerifyInputTypes(v))
      .AddVerifyObject<IGqlpOutputField>(v => new VerifyOutputTypes(v))
    );

  public static IServiceCollection AddVerifiers(this IServiceCollection services, Action<IVerifierRepositoryBuilder> config)
  {
    VerifierRepositoryBuilder builder = new();
    config?.Invoke(builder);
    services.AddSingleton(builder.Build());
    services.TryAddSingleton<IVerifierRepository, VerifierRepository>();
    return services;
  }

  private static IVerifierRepositoryBuilder AddVerifyUsageIdentified<TUsage, TIdentified>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyIdentified<TUsage, TIdentified>> identifiedFactory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => builder
      .AddIdentified(identifiedFactory)
      .TryAddVerify<TUsage>(v => new NullVerifierError<TUsage>(v))
      .TryAddVerify<TIdentified>(v => new NullVerifierError<TIdentified>(v));

  private static IVerifierRepositoryBuilder AddVerifyAliased<TAliased>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyAliased<TAliased>> aliasedFactory)
    where TAliased : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .TryAddVerify<TAliased>(v => new NullVerifierError<TAliased>(v));

  private static IVerifierRepositoryBuilder AddVerifyUsageAliased<TUsage>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyAliased<TUsage>> aliasedFactory,
    VerifierFactory<IVerifyUsage<TUsage>> usageFactory)
    where TUsage : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .AddUsage(usageFactory)
      .TryAddVerify<TUsage>(v => new NullVerifierError<TUsage>(v));

  private static IVerifierRepositoryBuilder AddVerifyObject<TField>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyUsage<IGqlpObject<TField>>> usageFactory)
    where TField : IGqlpObjField
    => builder
      .AddAliased<IGqlpObject<TField>>(v => new ObjectsAliasedVerifier<TField>(v))
      .AddUsage(usageFactory)
      .TryAddVerify<IGqlpObject<TField>>(v => new NullVerifierError<IGqlpObject<TField>>(v));
}
