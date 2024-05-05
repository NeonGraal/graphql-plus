using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Verification.Operation;
using GqlPlus.Verification.Schema;
using GqlPlus.Verification.Schema.Globals;
using GqlPlus.Verification.Schema.Objects;
using GqlPlus.Verification.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Verification;

public static class AllVerifiers
{
  public static IServiceCollection AddVerifiers(this IServiceCollection services)
    => services
      // Operation
      .AddVerify<IGqlpOperation, VerifyOperation>()
      .AddVerifyUsageNamed<IGqlpArgument, IGqlpVariable, VerifyVariableUsage>()
      .AddVerifyUsageNamed<IGqlpSpread, IGqlpFragment, VerifyFragmentUsage>()
      .AddVerify<IGqlpVariable, VerifyVariable>()
      // Schema
      .AddVerify<IGqlpSchema, VerifySchema>()
      .AddVerifyAliased<IGqlpSchemaCategory, VerifyCategoryAliased>()
      .AddVerifyUsageAliased<IGqlpSchemaCategory, OutputDeclAst, VerifyCategoryOutput>()
      .AddVerifyAliased<IGqlpSchemaDirective, VerifyDirectiveAliased>()
      .AddVerifyUsageAliased<IGqlpSchemaDirective, InputDeclAst, VerifyDirectiveInput>()
      .AddVerifyAliased<OptionDeclAst, VerifyOptionAliased>()
      // Schema Types
      .AddVerify<AstType[], VerifyAllTypes>()
      .AddVerifyAliased<AstType, VerifyAllTypesAliased>()
      .AddVerifyAliased<EnumDeclAst, VerifyEnumsAliased>()
      .AddVerifyUsageAliased<EnumDeclAst, AstType, VerifyEnumTypes>()
      .AddVerifyAliased<DualDeclAst, VerifyDualsAliased>()
      .AddVerifyUsageAliased<DualDeclAst, AstType, VerifyDualTypes>()
      .AddVerifyAliased<InputDeclAst, VerifyInputsAliased>()
      .AddVerifyUsageAliased<InputDeclAst, AstType, VerifyInputTypes>()
      .AddVerifyAliased<OutputDeclAst, VerifyOutputsAliased>()
      .AddVerifyUsageAliased<OutputDeclAst, AstType, VerifyOutputTypes>()
      .AddVerifyAliased<AstDomain, VerifyDomainsAliased>()
      .AddVerifyUsageAliased<AstDomain, AstType, VerifyDomainTypes>()
      .AddVerifyDomainContext<AstDomainVerifier<DomainTrueFalseAst>>()
      .AddVerifyDomainContext<VerifyDomainEnum>()
      .AddVerifyDomainContext<AstDomainVerifier<DomainRangeAst>>()
      .AddVerifyDomainContext<AstDomainVerifier<DomainRegexAst>>()
      .AddVerifyAliased<UnionDeclAst, VerifyUnionsAliased>()
      .AddVerifyUsageAliased<UnionDeclAst, AstType, VerifyUnionTypes>()
    ;

  public static IServiceCollection AddVerify<TValue, TService>(this IServiceCollection services)
    where TService : class, IVerify<TValue>
    => services.AddSingleton<IVerify<TValue>, TService>();

  public static IServiceCollection TryAddVerify<TValue, TService>(this IServiceCollection services)
    where TService : class, IVerify<TValue>
  {
    services.TryAddSingleton<IVerify<TValue>, TService>();
    return services;
  }

  public static IServiceCollection AddVerifyUsageNamed<TUsage, TNamed, TService>(this IServiceCollection services)
    where TService : class, IVerifyNamed<TUsage, TNamed>
    where TUsage : IGqlpError
    where TNamed : IGqlpNamed
  => services
      .AddSingleton<IVerifyNamed<TUsage, TNamed>, TService>()
      .TryAddVerify<TUsage, NullVerifierError<TUsage>>()
      .TryAddVerify<TNamed, NullVerifierError<TNamed>>();

  public static IServiceCollection AddVerifyAliased<TAliased, TService>(this IServiceCollection services)
    where TService : class, IVerifyAliased<TAliased>
    where TAliased : IGqlpAliased
    => services
      .AddSingleton<IVerifyAliased<TAliased>, TService>()
      .TryAddVerify<TAliased, NullVerifierError<TAliased>>();

  public static IServiceCollection AddVerifyUsageAliased<TUsage, TAliased, TService>(this IServiceCollection services)
    where TService : class, IVerifyUsage<TUsage, TAliased>
    where TUsage : IGqlpError
    where TAliased : AstAliased
    => services
      .AddSingleton<IVerifyUsage<TUsage, TAliased>, TService>()
      .TryAddVerify<TUsage, NullVerifierError<TUsage>>()
      .TryAddVerify<TAliased, NullVerifier<TAliased>>();

  public static IServiceCollection AddVerifyDomainContext<TService>(this IServiceCollection services)
    where TService : class, IVerifyDomain
    => services.AddSingleton<IVerifyDomain, TService>();
}
