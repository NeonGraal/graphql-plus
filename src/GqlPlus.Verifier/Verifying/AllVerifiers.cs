using System.Diagnostics.CodeAnalysis;
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
  public static IVerifierRepositoryBuilder AddSchemaVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        // Schema
        .AddVerify(v => new VerifySchema(v))
        .AddSchemaGlobalVerifiers()
        .AddVerify(v => new VerifyAllTypes(v))
        .AddVerifyAliased(v => new VerifyAllTypesAliased(v))
        .AddSchemaSimpleVerifiers()
        .AddSchemaObjectVerifiers();

  public static IVerifierRepositoryBuilder AddSchemaGlobalVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddVerifyUsageAliased(
          v => new VerifyCategoryAliased(v),
          v => new VerifyCategoryOutput(v))
        .AddVerifyUsageAliased(
          v => new VerifyDirectiveAliased(v),
          v => new VerifyDirectiveInput(v))
        .AddVerifyAliased(v => new VerifyOptionAliased(v));

  public static IVerifierRepositoryBuilder AddSchemaSimpleVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddSchemaDomainVerifiers()
        .AddVerifyUsageAliased(
          v => new VerifyEnumsAliased(v),
          v => new VerifyEnumTypes(v))
        .AddVerifyUsageAliased(
          v => new VerifyUnionsAliased(v),
          v => new VerifyUnionTypes(v));

  public static IVerifierRepositoryBuilder AddSchemaDomainVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddVerifyUsageAliased(
          v => new VerifyDomainsAliased(v),
          v => new VerifyDomainTypes(v))
        .AddDomain(v => new AstDomainVerifier<IGqlpDomainRange>(v))
        .AddDomain(v => new AstDomainVerifier<IGqlpDomainRegex>(v))
        .AddDomain(v => new AstDomainVerifier<IGqlpDomainTrueFalse>(v))
        .AddDomain(v => new VerifyDomainEnum(v));

  public static IVerifierRepositoryBuilder AddSchemaObjectVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddVerifyObject(TypeKind.Dual, v => new VerifyDualTypes(v))
        .AddVerifyObject(TypeKind.Input, v => new VerifyInputTypes(v))
        .AddVerifyObject(TypeKind.Output, v => new VerifyOutputTypes(v));

  public static IVerifierRepositoryBuilder AddOperationVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
      .AddVerify(v => new VerifyOperation(v))
      .AddVerify(_ => new VerifyVariable())
      .AddVerifyUsageIdentified(v => new VerifyVariableUsage(v))
      .AddVerifyUsageIdentified(v => new VerifyFragmentUsage(v));

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
    Factory<IVerifyIdentified<TUsage, TIdentified>, IVerifierRepository> identifiedFactory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => builder
      .AddIdentified(identifiedFactory)
      .TryAddVerify(v => new NullVerifierError<TUsage>(v))
      .TryAddVerify(v => new NullVerifierError<TIdentified>(v));

  private static IVerifierRepositoryBuilder AddVerifyAliased<TAliased>(
    this IVerifierRepositoryBuilder builder,
    Factory<IVerifyAliased<TAliased>, IVerifierRepository> aliasedFactory)
    where TAliased : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .TryAddVerify(v => new NullVerifierError<TAliased>(v));

  private static IVerifierRepositoryBuilder AddVerifyUsageAliased<TUsage>(
    this IVerifierRepositoryBuilder builder,
    Factory<IVerifyAliased<TUsage>, IVerifierRepository> aliasedFactory,
    Factory<IVerifyUsage<TUsage>, IVerifierRepository> usageFactory)
    where TUsage : IGqlpAliased
    => builder
      .AddAliased(aliasedFactory)
      .AddUsage(usageFactory)
      .TryAddVerify(v => new NullVerifierError<TUsage>(v));

  private static IVerifierRepositoryBuilder AddVerifyObject<TField>(
    this IVerifierRepositoryBuilder builder,
    TypeKind fieldKind,
    Factory<IVerifyUsage<IGqlpObject<TField>>, IVerifierRepository> usageFactory)
    where TField : IGqlpObjField
    => builder
      .AddAliased(v => new ObjectsAliasedVerifier<TField>(v, fieldKind))
      .AddUsage(usageFactory)
      .TryAddVerify(v => new NullVerifierError<IGqlpObject<TField>>(v));
}
