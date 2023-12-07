using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
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
      .AddVerifyUsageAliased<EnumDeclAst, AstType, VerifyEnumTypes>()
      .AddVerifyAliased<InputDeclAst, VerifyInputsAliased>()
      .AddVerifyUsageAliased<InputDeclAst, AstType, VerifyInputTypes>()
      .AddVerifyAliased<OutputDeclAst, VerifyOutputsAliased>()
      .AddVerifyUsageAliased<OutputDeclAst, AstType, VerifyOutputTypes>()
      .AddVerifyAliased<ScalarDeclAst, VerifyScalarsAliased>()
      .AddVerifyUsageAliased<ScalarDeclAst, AstType, VerifyScalarTypes>()
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
    where S : class, IVerifyUsageNamed<U, D>
    where U : AstBase where D : AstNamed
  => services
      .AddSingleton<IVerifyUsageNamed<U, D>, S>()
      .TryAddVerify<U, NullVerifier<U>>()
      .TryAddVerify<D, NullVerifier<D>>();

  public static IServiceCollection AddVerifyAliased<A, S>(this IServiceCollection services)
    where S : class, IVerifyAliased<A>
    where A : AstAliased
    => services
      .AddSingleton<IVerifyAliased<A>, S>()
      .TryAddVerify<A, NullVerifier<A>>()
      .TryAddMerge<A, NullMerger<A>>();

  public static IServiceCollection AddVerifyUsageAliased<U, A, S>(this IServiceCollection services)
    where S : class, IVerifyUsageAliased<U, A>
    where U : AstBase where A : AstAliased
    => services
      .AddSingleton<IVerifyUsageAliased<U, A>, S>()
      .TryAddVerify<U, NullVerifier<U>>()
      .TryAddVerify<A, NullVerifier<A>>();
}
