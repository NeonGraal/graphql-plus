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
        .AddVerify(VerifySchema.Factory)
        .AddSchemaGlobalVerifiers()
        .AddVerify(VerifyAllTypes.Factory)
        .AddVerifyAliased(VerifyAllTypesAliased.Factory)
        .AddSchemaSimpleVerifiers()
        .AddSchemaObjectVerifiers();

  public static IVerifierRepositoryBuilder AddSchemaGlobalVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddVerifyUsageAliased(
          VerifyCategoryAliased.Factory,
          VerifyCategoryOutput.Factory)
        .AddVerifyUsageAliased(
          VerifyDirectiveAliased.Factory,
          VerifyDirectiveInput.Factory)
        .AddVerifyAliased(VerifyOptionAliased.Factory);

  public static IVerifierRepositoryBuilder AddSchemaSimpleVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddSchemaDomainVerifiers()
        .AddVerifyUsageAliased(
          VerifyEnumsAliased.Factory,
          VerifyEnumTypes.Factory)
        .AddVerifyUsageAliased(
          VerifyUnionsAliased.Factory,
          VerifyUnionTypes.Factory);

  public static IVerifierRepositoryBuilder AddSchemaDomainVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddVerifyUsageAliased(
          VerifyDomainsAliased.Factory,
          VerifyDomainTypes.Factory)
        .AddDomain(AstDomainVerifier<IAstDomainRange>.Factory)
        .AddDomain(AstDomainVerifier<IAstDomainRegex>.Factory)
        .AddDomain(AstDomainVerifier<IAstDomainTrueFalse>.Factory)
        .AddDomain(VerifyDomainEnum.Factory);

  public static IVerifierRepositoryBuilder AddSchemaObjectVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
        .AddVerifyObject(TypeKind.Dual, VerifyDualTypes.Factory)
        .AddVerifyObject(TypeKind.Input, VerifyInputTypes.Factory)
        .AddVerifyObject(TypeKind.Output, VerifyOutputTypes.Factory);

  public static IVerifierRepositoryBuilder AddOperationVerifiers([NotNull] this IVerifierRepositoryBuilder builder)
    => builder
      .AddVerify(VerifyOperation.Factory)
      .AddVerify(VerifyVariable.Factory)
      .AddVerifyUsageIdentified(VerifyVariableUsage.Factory)
      .AddVerifyUsageIdentified(VerifyFragmentUsage.Factory);

  public static IServiceCollection AddVerifiers(this IServiceCollection services, Action<IVerifierRepositoryBuilder> config)
  {
    VerifierRepositoryBuilder builder = new();
    config?.Invoke(builder);
    services.AddSingleton(builder);
    services.TryAddSingleton<IVerifierRepository, VerifierRepository>();
    return services;
  }

  private static IVerifierRepositoryBuilder AddVerifyUsageIdentified<TUsage, TIdentified>(
    this IVerifierRepositoryBuilder builder,
    Factory<IVerifyIdentified<TUsage, TIdentified>, IVerifierRepository> identifiedFactory)
    where TUsage : IAstError
    where TIdentified : IAstIdentified
    => builder
      .AddIdentified(identifiedFactory)
      .TryAddVerify(NullVerifierError<TUsage>.Factory)
      .TryAddVerify(NullVerifierError<TIdentified>.Factory);

  private static IVerifierRepositoryBuilder AddVerifyAliased<TAliased>(
    this IVerifierRepositoryBuilder builder,
    Factory<IVerifyAliased<TAliased>, IVerifierRepository> aliasedFactory)
    where TAliased : IAstAliased
    => builder
      .AddAliased(aliasedFactory)
      .TryAddVerify(NullVerifierError<TAliased>.Factory);

  private static IVerifierRepositoryBuilder AddVerifyUsageAliased<TUsage>(
    this IVerifierRepositoryBuilder builder,
    Factory<IVerifyAliased<TUsage>, IVerifierRepository> aliasedFactory,
    Factory<IVerifyUsage<TUsage>, IVerifierRepository> usageFactory)
    where TUsage : IAstAliased
    => builder
      .AddAliased(aliasedFactory)
      .AddUsage(usageFactory)
      .TryAddVerify(NullVerifierError<TUsage>.Factory);

  private static IVerifierRepositoryBuilder AddVerifyObject<TField>(
    this IVerifierRepositoryBuilder builder,
    TypeKind fieldKind,
    Factory<IVerifyUsage<IAstObject<TField>>, IVerifierRepository> usageFactory)
    where TField : IAstObjField
    => builder
      .AddAliased(v => new ObjectsAliasedVerifier<TField>(v, fieldKind))
      .AddUsage(usageFactory)
      .TryAddVerify(NullVerifierError<IAstObject<TField>>.Factory);
}
