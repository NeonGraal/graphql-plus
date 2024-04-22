using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Objects;

internal class VerifyInputsAliased(
  IVerify<InputDeclAst> definition,
  IMerge<InputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<InputDeclAst>(definition, merger, logger)
{
  public override string Label => "Inputs";
}
