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
      // Schmea Types
      .AddVerify<AstType[], VerifyAllTypes>()
      .AddVerifyAliased<AstType, VerifyAllTypesAliased>()
      .AddVerifyAliased<EnumDeclAst, VerifyEnumsAliased>()
      .AddVerifyUsageAliased<EnumDeclAst, EnumDeclAst, VerifyEnumTypes>()
      .AddVerifyAliased<InputDeclAst, VerifyInputsAliased>()
      .AddVerifyUsageAliased<InputDeclAst, AstType, VerifyInputTypes>()
      .AddVerifyAliased<OutputDeclAst, VerifyOutputsAliased>()
      .AddVerifyUsageAliased<OutputDeclAst, AstType, VerifyOutputTypes>()
      .AddVerifyAliased<ScalarDeclAst, VerifyScalarsAliased>()
    ;

  public static IServiceCollection AddVerify<T, S>(this IServiceCollection services)
    where S : class, IVerify<T>
    => services.AddSingleton<IVerify<T>, S>();

  public static IServiceCollection TryAddVerify<T, S>(this IServiceCollection services)
    where S : class, IVerify<T>
  {
    services.TryAddSingleton<IVerify<T>, S>();
    return services;
  }

  public static IServiceCollection AddVerifyUsageNamed<U, D, S>(this IServiceCollection services)
    where S : class, IVerifyNamed<U, D>
    where U : AstBase where D : AstNamed
  => services
      .AddSingleton<IVerifyNamed<U, D>, S>()
      .TryAddVerify<U, NullVerifier<U>>()
      .TryAddVerify<D, NullVerifier<D>>();

  public static IServiceCollection AddVerifyAliased<A, S>(this IServiceCollection services)
    where S : class, IVerifyAliased<A>
    where A : AstAliased
    => services
      .AddSingleton<IVerifyAliased<A>, S>()
      .TryAddVerify<A, NullVerifier<A>>();

  public static IServiceCollection AddVerifyUsageAliased<U, A, S>(this IServiceCollection services)
    where S : class, IVerifyUsage<U, A>
    where U : AstBase where A : AstAliased
    => services
      .AddSingleton<IVerifyUsage<U, A>, S>()
      .TryAddVerify<U, NullVerifier<U>>()
      .TryAddVerify<A, NullVerifier<A>>();
}
