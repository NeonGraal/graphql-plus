using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Simple;

internal class VerifyUnionsAliased(
  IVerify<UnionDeclAst> definition,
  IMerge<UnionDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<UnionDeclAst>(definition, merger, logger)
{
  public override string Label => "Unions";
}
