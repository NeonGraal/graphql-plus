using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputsAliased(
  IVerify<OutputDeclAst> definition,
  IMerge<OutputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<OutputDeclAst>(definition, merger, logger)
{
  public override string Label => "Outputs";
}
