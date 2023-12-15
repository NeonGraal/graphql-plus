using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyEnumsAliased(
  IVerify<EnumDeclAst> definition,
  IMerge<EnumDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<EnumDeclAst>(definition, merger, logger)
{
  public override string Label => "Enums";

  protected override object GroupKey(EnumDeclAst item) => "";
}
