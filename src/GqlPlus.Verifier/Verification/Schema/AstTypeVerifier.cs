using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstTypeVerifier<TAst, TContext>(
  IVerifyAliased<TAst> aliased
) : UsageVerifier<TAst, AstType, TContext>(aliased)
  where TAst : AstType
  where TContext : UsageContext
{ }
