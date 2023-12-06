using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Verification;

public static class Verifiers
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
      .AddVerifyAliased<CategoryDeclAst, VerifyCategories>()
      .AddVerifyUsageAliased<CategoryDeclAst, OutputDeclAst, VerifyCategoryOutput>()
      .AddVerifyAliased<DirectiveDeclAst, VerifyDirectives>()
      .AddVerifyUsageAliased<DirectiveDeclAst, InputDeclAst, VerifyDirectiveInput>()
      // Schmea Types
      .AddVerify<AstType[], VerifyAllTypes>()
      .AddVerifyAliased<EnumDeclAst, VerifyEnums>()
      .AddVerifyUsageAliased<EnumDeclAst, AstType, VerifyEnumTypes>()
      .AddVerifyAliased<InputDeclAst, VerifyInputs>()
      .AddVerifyUsageAliased<InputDeclAst, AstType, VerifyInputTypes>()
      .AddVerifyAliased<OutputDeclAst, VerifyOutputs>()
      .AddVerifyUsageAliased<OutputDeclAst, AstType, VerifyOutputTypes>()
      .AddVerifyAliased<ScalarDeclAst, VerifyScalars>()
      .AddVerifyUsageAliased<ScalarDeclAst, AstType, VerifyScalarTypes>()
    ;

  public static IServiceCollection AddVerify<T, S>(this IServiceCollection services)
    where S : class, IVerify<T>
    => services.AddSingleton<IVerify<T>, S>();

  public static IServiceCollection AddVerifyUsageNamed<U, D, S>(this IServiceCollection services)
    where S : class, IVerifyUsageNamed<U, D>
    where U : AstBase where D : AstNamed
    => services
      .AddSingleton<IVerifyUsageNamed<U, D>, S>()
      .AddSingleton<IVerify<U>, NullVerifier<U>>()
      .AddSingleton<IVerify<D>, NullVerifier<D>>()
    ;

  public static IServiceCollection AddVerifyAliased<A, S>(this IServiceCollection services)
    where S : class, IVerifyAliased<A>
    where A : AstAliased
    => services
      .AddSingleton<IVerifyAliased<A>, S>()
      .AddSingleton<IVerify<A>, NullVerifier<A>>()
    ;

  public static IServiceCollection AddVerifyUsageAliased<U, A, S>(this IServiceCollection services)
    where S : class, IVerifyUsageAliased<U, A>
    where U : AstBase where A : AstAliased
    => services
      .AddSingleton<IVerifyUsageAliased<U, A>, S>()
      .AddSingleton<IVerify<U>, NullVerifier<U>>()
      .AddSingleton<IVerify<A>, NullVerifier<A>>()
    ;
}
