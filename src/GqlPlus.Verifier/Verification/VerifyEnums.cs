using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyEnums(IVerify<EnumDeclAst> definition)
  : AliasedVerifier<EnumDeclAst>(definition)
{
  public override string Label => "Enums";

  protected override object GroupKey(EnumDeclAst aliased) => TokenMessages.Empty;
}
