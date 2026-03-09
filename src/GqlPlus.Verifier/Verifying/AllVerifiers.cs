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
      .AddVerify<IGqlpOperation>(v => new VerifyOperation(
        v.IdentifiedFor<IGqlpArg, IGqlpVariable>(),
        v.IdentifiedFor<IGqlpSpread, IGqlpFragment>()))
      .AddVerify<IGqlpVariable>(_ => new VerifyVariable())
      .AddVerifyUsageIdentified<IGqlpArg, IGqlpVariable>(
        v => new VerifyVariableUsage(v.VerifierFor<IGqlpArg>(), v.VerifierFor<IGqlpVariable>()))
      .AddVerifyUsageIdentified<IGqlpSpread, IGqlpFragment>(
        v => new VerifyFragmentUsage(v.VerifierFor<IGqlpSpread>(), v.VerifierFor<IGqlpFragment>()))
      // Schema
      .AddVerify<IGqlpSchema>(v => new VerifySchema(
        v.UsageFor<IGqlpSchemaCategory>(),
        v.UsageFor<IGqlpSchemaDirective>(),
        v.AliasedFor<IGqlpSchemaOption>(),
        v.AliasedFor<IGqlpType>(),
        v.VerifierFor<IGqlpType[]>()))
      .AddVerifyUsageAliased<IGqlpSchemaCategory>(
        v => new VerifyCategoryAliased(v.VerifierFor<IGqlpSchemaCategory>(), v.MergeFor<IGqlpSchemaCategory>(), v.LoggerFactory),
        v => new VerifyCategoryOutput(v.AliasedFor<IGqlpSchemaCategory>()))
      .AddVerifyUsageAliased<IGqlpSchemaDirective>(
        v => new VerifyDirectiveAliased(v.VerifierFor<IGqlpSchemaDirective>(), v.MergeFor<IGqlpSchemaDirective>(), v.LoggerFactory),
        v => new VerifyDirectiveInput(v.AliasedFor<IGqlpSchemaDirective>()))
      .AddVerifyAliased<IGqlpSchemaOption>(
        v => new VerifyOptionAliased(v.VerifierFor<IGqlpSchemaOption>(), v.MergeFor<IGqlpSchemaOption>(), v.LoggerFactory))
      // Schema Types
      .AddVerify<IGqlpType[]>(v => new VerifyAllTypes(
        v.UsageFor<IGqlpObject<IGqlpDualField>>(),
        v.UsageFor<IGqlpEnum>(),
        v.UsageFor<IGqlpObject<IGqlpInputField>>(),
        v.UsageFor<IGqlpObject<IGqlpOutputField>>(),
        v.UsageFor<IGqlpDomain>(),
        v.UsageFor<IGqlpUnion>()))
      .AddVerifyAliased<IGqlpType>(
        v => new VerifyAllTypesAliased(v.MergeFor<IGqlpType>(), v.LoggerFactory))
      // Simple Types
      .AddVerifyUsageAliased<IGqlpDomain>(
        v => new VerifyDomainsAliased(v.VerifierFor<IGqlpDomain>(), v.MergeFor<IGqlpDomain>(), v.LoggerFactory),
        v => new VerifyDomainTypes(v.AliasedFor<IGqlpDomain>(), v.GetDomains()))
      .AddDomain(v => new AstDomainVerifier<IGqlpDomainRange>(v.MergeFor<IGqlpDomainRange>()))
      .AddDomain(v => new AstDomainVerifier<IGqlpDomainRegex>(v.MergeFor<IGqlpDomainRegex>()))
      .AddDomain(v => new AstDomainVerifier<IGqlpDomainTrueFalse>(v.MergeFor<IGqlpDomainTrueFalse>()))
      .AddDomain(v => new VerifyDomainEnum(v.MergeFor<IGqlpDomainLabel>()))
      .AddVerifyUsageAliased<IGqlpEnum>(
        v => new VerifyEnumsAliased(v.VerifierFor<IGqlpEnum>(), v.MergeFor<IGqlpEnum>(), v.LoggerFactory),
        v => new VerifyEnumTypes(v.AliasedFor<IGqlpEnum>(), v.MergeFor<IGqlpEnumLabel>()))
      .AddVerifyUsageAliased<IGqlpUnion>(
        v => new VerifyUnionsAliased(v.VerifierFor<IGqlpUnion>(), v.MergeFor<IGqlpUnion>(), v.LoggerFactory),
        v => new VerifyUnionTypes(v.AliasedFor<IGqlpUnion>(), v.MergeFor<IGqlpUnionMember>()))
      // Object Types
      .AddVerifyObject<IGqlpDualField>(v => new VerifyDualTypes(MakeObjectParams<IGqlpDualField>(v)))
      .AddVerifyObject<IGqlpInputField>(v => new VerifyInputTypes(MakeObjectParams<IGqlpInputField>(v)))
      .AddVerifyObject<IGqlpOutputField>(v => new VerifyOutputTypes(MakeObjectParams<IGqlpOutputField>(v)))
    );

  public static IServiceCollection AddVerifiers(this IServiceCollection services, Action<IVerifierRepositoryBuilder> config)
  {
    VerifierRepositoryBuilder builder = new();
    config?.Invoke(builder);
    services.AddSingleton(builder.Build());
    services.TryAddSingleton<IVerifierRepository, VerifierRepository>();
    return services;
  }

  private static ObjectVerifierParams<TField> MakeObjectParams<TField>(IVerifierRepository v)
    where TField : IGqlpObjField
    => new(
      v.AliasedFor<IGqlpObject<TField>>(),
      v.MergeFor<TField>(),
      v.MergeFor<IGqlpAlternate>(),
      v.Matchers.MatcherFor<IGqlpTypeArg>(),
      v.FieldKindFor<TField>());

  private static IVerifierRepositoryBuilder AddVerifyUsageIdentified<TUsage, TIdentified>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyIdentified<TUsage, TIdentified>> identifiedFactory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => builder
      .AddIdentified(identifiedFactory)
      .TryAddVerify<TUsage>(v => new NullVerifierError<TUsage>(v.LoggerFactory))
      .TryAddVerify<TIdentified>(v => new NullVerifierError<TIdentified>(v.LoggerFactory));

  private static IVerifierRepositoryBuilder AddVerifyAliased<TAliased>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyAliased<TAliased>> aliasedFactory)
    where TAliased : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .TryAddVerify<TAliased>(v => new NullVerifierError<TAliased>(v.LoggerFactory));

  private static IVerifierRepositoryBuilder AddVerifyUsageAliased<TUsage>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyAliased<TUsage>> aliasedFactory,
    VerifierFactory<IVerifyUsage<TUsage>> usageFactory)
    where TUsage : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .AddUsage(usageFactory)
      .TryAddVerify<TUsage>(v => new NullVerifierError<TUsage>(v.LoggerFactory));

  private static IVerifierRepositoryBuilder AddVerifyObject<TField>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyUsage<IGqlpObject<TField>>> usageFactory)
    where TField : IGqlpObjField
    => builder
      .AddAliased<IGqlpObject<TField>>(v => new ObjectsAliasedVerifier<TField>(
        v.VerifierFor<IGqlpObject<TField>>(),
        v.MergeFor<IGqlpObject<TField>>(),
        v.LoggerFactory,
        v.FieldKindFor<TField>()))
      .AddUsage(usageFactory)
      .TryAddVerify<IGqlpObject<TField>>(v => new NullVerifierError<IGqlpObject<TField>>(v.LoggerFactory));
}
