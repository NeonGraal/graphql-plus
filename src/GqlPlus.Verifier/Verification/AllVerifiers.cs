using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Verification.Operation;
using GqlPlus.Verifier.Verification.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Verifier.Verification;

public static class AllVerifiers
{
  public static IServiceCollection AddVerifiers(this IServiceCollection services)
    => services
      // Operation
      .AddVerify<OperationAst, VerifyOperation>()
      .AddVerifyUsageNamed<ArgumentAst, VariableAst, VerifyVariableUsage>()
      .AddVerifyUsageNamed<SpreadAst, FragmentAst, VerifyFragmentUsage>()
      .AddVerify<VariableAst, VerifyVariable>()
      // Schema
      .AddVerify<SchemaAst, VerifySchema>()
      .AddVerifyAliased<CategoryDeclAst, VerifyCategoryAliased>()
      .AddVerifyUsageAliased<CategoryDeclAst, OutputDeclAst, VerifyCategoryOutput>()
      .AddVerifyAliased<DirectiveDeclAst, VerifyDirectiveAliased>()
      .AddVerifyUsageAliased<DirectiveDeclAst, InputDeclAst, VerifyDirectiveInput>()
      .AddVerifyAliased<OptionDeclAst, VerifyOptionAliased>()
      // Schema Types
      .AddVerify<AstType[], VerifyAllTypes>()
      .AddVerifyAliased<AstType, VerifyAllTypesAliased>()
      .AddVerifyAliased<EnumDeclAst, VerifyEnumsAliased>()
      .AddVerifyUsageAliased<EnumDeclAst, AstType, VerifyEnumTypes>()
      .AddVerifyAliased<InputDeclAst, VerifyInputsAliased>()
      .AddVerifyUsageAliased<InputDeclAst, AstType, VerifyInputTypes>()
      .AddVerifyAliased<OutputDeclAst, VerifyOutputsAliased>()
      .AddVerifyUsageAliased<OutputDeclAst, AstType, VerifyOutputTypes>()
      .AddVerifyAliased<AstScalar, VerifyScalarsAliased>()
      .AddVerifyUsageAliased<AstScalar, AstType, VerifyScalarTypes>()
      .AddVerifyScalarContext<AstScalarVerifier<ScalarTrueFalseAst>>()
      .AddVerifyScalarContext<VerifyScalarEnum>()
      .AddVerifyScalarContext<AstScalarVerifier<ScalarRangeAst>>()
      .AddVerifyScalarContext<AstScalarVerifier<ScalarRegexAst>>()
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
    where TUsage : AstAbbreviated where TNamed : AstNamed
  => services
      .AddSingleton<IVerifyNamed<TUsage, TNamed>, TService>()
      .TryAddVerify<TUsage, NullVerifier<TUsage>>()
      .TryAddVerify<TNamed, NullVerifier<TNamed>>();

  public static IServiceCollection AddVerifyAliased<TAliased, TService>(this IServiceCollection services)
    where TService : class, IVerifyAliased<TAliased>
    where TAliased : AstAliased
    => services
      .AddSingleton<IVerifyAliased<TAliased>, TService>()
      .TryAddVerify<TAliased, NullVerifier<TAliased>>();

  public static IServiceCollection AddVerifyUsageAliased<TUsage, TAliased, TService>(this IServiceCollection services)
    where TService : class, IVerifyUsage<TUsage, TAliased>
    where TUsage : AstAbbreviated where TAliased : AstAliased
    => services
      .AddSingleton<IVerifyUsage<TUsage, TAliased>, TService>()
      .TryAddVerify<TUsage, NullVerifier<TUsage>>()
      .TryAddVerify<TAliased, NullVerifier<TAliased>>();

  public static IServiceCollection AddVerifyScalarContext<TService>(this IServiceCollection services)
    where TService : class, IVerifyScalar
    => services.AddSingleton<IVerifyScalar, TService>();
}
