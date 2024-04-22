using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Globals;

internal class VerifyCategoryAliased(
  IVerify<CategoryDeclAst> definition,
  IMerge<CategoryDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<CategoryDeclAst>(definition, merger, logger)
{
  public override string Label => "Categories";
}
