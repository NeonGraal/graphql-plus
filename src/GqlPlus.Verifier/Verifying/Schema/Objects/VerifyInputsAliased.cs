using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputsAliased(
  IVerify<InputDeclAst> definition,
  IMerge<InputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<InputDeclAst>(definition, merger, logger)
{
  public override string Label => "Inputs";
}
