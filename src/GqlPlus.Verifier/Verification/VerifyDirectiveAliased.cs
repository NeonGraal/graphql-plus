using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyDirectiveAliased(
  IVerify<DirectiveDeclAst> definition,
   IMerge<DirectiveDeclAst> merger
) : AliasedVerifier<DirectiveDeclAst>(definition, merger)
{
  public override string Label => "Directives";

  protected override object GroupKey(DirectiveDeclAst aliased) => "";
}
