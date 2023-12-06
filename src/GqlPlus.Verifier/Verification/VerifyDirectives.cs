using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyDirectives(IVerify<DirectiveDeclAst> definition)
  : AliasedVerifier<DirectiveDeclAst>(definition)
{
  public override string Label => "Directives";

  protected override object GroupKey(DirectiveDeclAst aliased) => "";
}
