using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
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
      .AddVerify<IGqlpOperation>((v, _) => new VerifyOperation(
        v.IdentifiedFor<IGqlpArg, IGqlpVariable>(),
        v.IdentifiedFor<IGqlpSpread, IGqlpFragment>()))
      .AddVerify<IGqlpVariable>((_, _) => new VerifyVariable())
      .AddVerifyUsageIdentified<IGqlpArg, IGqlpVariable>(
        (v, _) => new VerifyVariableUsage(v.VerifierFor<IGqlpArg>(), v.VerifierFor<IGqlpVariable>()))
      .AddVerifyUsageIdentified<IGqlpSpread, IGqlpFragment>(
        (v, _) => new VerifyFragmentUsage(v.VerifierFor<IGqlpSpread>(), v.VerifierFor<IGqlpFragment>()))
      // Schema
      .AddVerify<IGqlpSchema>((v, _) => new VerifySchema(
        v.UsageFor<IGqlpSchemaCategory>(),
        v.UsageFor<IGqlpSchemaDirective>(),
        v.AliasedFor<IGqlpSchemaOption>(),
        v.AliasedFor<IGqlpType>(),
        v.VerifierFor<IGqlpType[]>()))
      .AddVerifyUsageAliased<IGqlpSchemaCategory>(
        (v, s) => new VerifyCategoryAliased(v.VerifierFor<IGqlpSchemaCategory>(), s.GetRequiredService<IMerge<IGqlpSchemaCategory>>(), s.GetRequiredService<ILoggerFactory>()),
        (v, _) => new VerifyCategoryOutput(v.AliasedFor<IGqlpSchemaCategory>()))
      .AddVerifyUsageAliased<IGqlpSchemaDirective>(
        (v, s) => new VerifyDirectiveAliased(v.VerifierFor<IGqlpSchemaDirective>(), s.GetRequiredService<IMerge<IGqlpSchemaDirective>>(), s.GetRequiredService<ILoggerFactory>()),
        (v, _) => new VerifyDirectiveInput(v.AliasedFor<IGqlpSchemaDirective>()))
      .AddVerifyAliased<IGqlpSchemaOption>(
        (v, s) => new VerifyOptionAliased(v.VerifierFor<IGqlpSchemaOption>(), s.GetRequiredService<IMerge<IGqlpSchemaOption>>(), s.GetRequiredService<ILoggerFactory>()))
      // Schema Types
      .AddVerify<IGqlpType[]>((v, _) => new VerifyAllTypes(
        v.UsageFor<IGqlpObject<IGqlpDualField>>(),
        v.UsageFor<IGqlpEnum>(),
        v.UsageFor<IGqlpObject<IGqlpInputField>>(),
        v.UsageFor<IGqlpObject<IGqlpOutputField>>(),
        v.UsageFor<IGqlpDomain>(),
        v.UsageFor<IGqlpUnion>()))
      .AddVerifyAliased<IGqlpType>(
        (_, s) => new VerifyAllTypesAliased(s.GetRequiredService<IMerge<IGqlpType>>(), s.GetRequiredService<ILoggerFactory>()))
      // Simple Types
      .AddVerifyUsageAliased<IGqlpDomain>(
        (v, s) => new VerifyDomainsAliased(v.VerifierFor<IGqlpDomain>(), s.GetRequiredService<IMerge<IGqlpDomain>>(), s.GetRequiredService<ILoggerFactory>()),
        (v, _) => new VerifyDomainTypes(v.AliasedFor<IGqlpDomain>(), v.GetDomains()))
      .AddDomain((_, s) => new AstDomainVerifier<IGqlpDomainRange>(s.GetRequiredService<IMerge<IGqlpDomainRange>>()))
      .AddDomain((_, s) => new AstDomainVerifier<IGqlpDomainRegex>(s.GetRequiredService<IMerge<IGqlpDomainRegex>>()))
      .AddDomain((_, s) => new AstDomainVerifier<IGqlpDomainTrueFalse>(s.GetRequiredService<IMerge<IGqlpDomainTrueFalse>>()))
      .AddDomain((_, s) => new VerifyDomainEnum(s.GetRequiredService<IMerge<IGqlpDomainLabel>>()))
      .AddVerifyUsageAliased<IGqlpEnum>(
        (v, s) => new VerifyEnumsAliased(v.VerifierFor<IGqlpEnum>(), s.GetRequiredService<IMerge<IGqlpEnum>>(), s.GetRequiredService<ILoggerFactory>()),
        (v, s) => new VerifyEnumTypes(v.AliasedFor<IGqlpEnum>(), s.GetRequiredService<IMerge<IGqlpEnumLabel>>()))
      .AddVerifyUsageAliased<IGqlpUnion>(
        (v, s) => new VerifyUnionsAliased(v.VerifierFor<IGqlpUnion>(), s.GetRequiredService<IMerge<IGqlpUnion>>(), s.GetRequiredService<ILoggerFactory>()),
        (v, s) => new VerifyUnionTypes(v.AliasedFor<IGqlpUnion>(), s.GetRequiredService<IMerge<IGqlpUnionMember>>()))
      // Object Types
      .AddVerifyObject<IGqlpDualField>((v, s) => new VerifyDualTypes(MakeObjectParams<IGqlpDualField>(v, s)))
      .AddVerifyObject<IGqlpInputField>((v, s) => new VerifyInputTypes(MakeObjectParams<IGqlpInputField>(v, s)))
      .AddVerifyObject<IGqlpOutputField>((v, s) => new VerifyOutputTypes(MakeObjectParams<IGqlpOutputField>(v, s)))
    );

  public static IServiceCollection AddVerifiers(this IServiceCollection services, Action<IVerifierRepositoryBuilder> config)
  {
    VerifierRepositoryBuilder builder = new();
    config?.Invoke(builder);
    services.AddSingleton(builder.Build());
    services.TryAddSingleton<IVerifierRepository, VerifierRepository>();
    return services;
  }

  private static ObjectVerifierParams<TField> MakeObjectParams<TField>(IVerifierRepository v, IServiceProvider s)
    where TField : IGqlpObjField
    => new(
      v.AliasedFor<IGqlpObject<TField>>(),
      s.GetRequiredService<IMerge<TField>>(),
      s.GetRequiredService<IMerge<IGqlpAlternate>>(),
      s.GetRequiredService<Matcher<IGqlpTypeArg>.D>(),
      s.GetRequiredService<IGqlpFieldKind<TField>>());

  private static IVerifierRepositoryBuilder AddVerifyUsageIdentified<TUsage, TIdentified>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyIdentified<TUsage, TIdentified>> identifiedFactory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => builder
      .AddIdentified(identifiedFactory)
      .TryAddVerify<TUsage>((_, s) => new NullVerifierError<TUsage>(s.GetRequiredService<ILoggerFactory>()))
      .TryAddVerify<TIdentified>((_, s) => new NullVerifierError<TIdentified>(s.GetRequiredService<ILoggerFactory>()));

  private static IVerifierRepositoryBuilder AddVerifyAliased<TAliased>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyAliased<TAliased>> aliasedFactory)
    where TAliased : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .TryAddVerify<TAliased>((_, s) => new NullVerifierError<TAliased>(s.GetRequiredService<ILoggerFactory>()));

  private static IVerifierRepositoryBuilder AddVerifyUsageAliased<TUsage>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyAliased<TUsage>> aliasedFactory,
    VerifierFactory<IVerifyUsage<TUsage>> usageFactory)
    where TUsage : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .AddUsage(usageFactory)
      .TryAddVerify<TUsage>((_, s) => new NullVerifierError<TUsage>(s.GetRequiredService<ILoggerFactory>()));

  private static IVerifierRepositoryBuilder AddVerifyObject<TField>(
    this IVerifierRepositoryBuilder builder,
    VerifierFactory<IVerifyUsage<IGqlpObject<TField>>> usageFactory)
    where TField : IGqlpObjField
    => builder
      .AddAliased<IGqlpObject<TField>>((v, s) => new ObjectsAliasedVerifier<TField>(
        v.VerifierFor<IGqlpObject<TField>>(),
        s.GetRequiredService<IMerge<IGqlpObject<TField>>>(),
        s.GetRequiredService<ILoggerFactory>(),
        s.GetRequiredService<IGqlpFieldKind<TField>>()))
      .AddUsage(usageFactory)
      .TryAddVerify<IGqlpObject<TField>>((_, s) => new NullVerifierError<IGqlpObject<TField>>(s.GetRequiredService<ILoggerFactory>()));
}
