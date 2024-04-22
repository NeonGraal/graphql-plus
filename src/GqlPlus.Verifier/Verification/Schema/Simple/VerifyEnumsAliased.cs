using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Simple;

internal class VerifyEnumsAliased(
  IVerify<EnumDeclAst> definition,
  IMerge<EnumDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<EnumDeclAst>(definition, merger, logger)
{
  public override string Label => "Enums";
}
