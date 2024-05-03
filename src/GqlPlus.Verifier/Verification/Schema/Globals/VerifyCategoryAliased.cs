using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyCategoryAliased(
  IVerify<CategoryDeclAst> definition,
  IMerge<CategoryDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<CategoryDeclAst>(definition, merger, logger)
{
  public override string Label => "Categories";
}
