using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOutputsAliased(
  IVerify<OutputDeclAst> definition,
  IMerge<OutputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<OutputDeclAst>(definition, merger, logger)
{
  public override string Label => "Outputs";

  protected override object GroupKey(OutputDeclAst item) => item.Extends?.Name ?? "";
}
