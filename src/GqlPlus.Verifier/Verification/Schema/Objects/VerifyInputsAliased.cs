using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Objects;

internal class VerifyInputsAliased(
  IVerify<InputDeclAst> definition,
  IMerge<InputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<InputDeclAst>(definition, merger, logger)
{
  public override string Label => "Inputs";
}
