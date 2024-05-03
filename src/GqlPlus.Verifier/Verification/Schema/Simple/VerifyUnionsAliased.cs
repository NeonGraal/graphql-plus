using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyUnionsAliased(
  IVerify<UnionDeclAst> definition,
  IMerge<UnionDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<UnionDeclAst>(definition, merger, logger)
{
  public override string Label => "Unions";
}
