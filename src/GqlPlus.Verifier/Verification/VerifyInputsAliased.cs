using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyInputsAliased(
  IVerify<InputDeclAst> definition,
  IMerge<InputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<InputDeclAst>(definition, merger, logger)
{
  public override string Label => "Inputs";

  protected override object GroupKey(InputDeclAst item) => item.Extends?.Name ?? "";
}
