using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyEnums(IVerify<EnumAst> definition)
  : AliasedVerifier<EnumAst>(definition)
{
  public override string Label => "Enums";

  protected override object GroupKey(EnumAst aliased) => TokenMessages.Empty;
}
