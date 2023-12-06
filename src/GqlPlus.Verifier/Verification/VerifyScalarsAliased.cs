using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyScalarsAliased(
  IVerify<ScalarDeclAst> definition,
   IMerge<ScalarDeclAst> merger
) : AliasedVerifier<ScalarDeclAst>(definition, merger)
{
  public override string Label => "Scalars";

  protected override object GroupKey(ScalarDeclAst item) => item.Name + "-" + item.Kind;
}
