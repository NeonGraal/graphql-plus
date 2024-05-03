using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyEnumsAliased(
  IVerify<EnumDeclAst> definition,
  IMerge<EnumDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<EnumDeclAst>(definition, merger, logger)
{
  public override string Label => "Enums";
}
